from unittest import case

import pandas, sqlite3
from typing import Optional

DB_URL = "./db/db.sqlite3"

"""
    ORDERNUMBER,
    QUANTITYORDERED,
    PRICEEACH,
    ORDERLINENUMBER,
    SALES,
    ORDERDATE,
    STATUS,
    QTR_ID,
    MONTH_ID,
    YEAR_ID,
    PRODUCTLINE,
    MSRP,
    PRODUCTCODE,
    CUSTOMERNAME,
    PHONE,
    ADDRESSLINE1,
    ADDRESSLINE2,
    CITY,
    STATE,
    POSTALCODE,
    COUNTRY,
    TERRITORY,
    CONTACTLASTNAME,
    CONTACTFIRSTNAME,
    DEALSIZE
"""

definitions = list()
tools = dict()

#get_group_sales definition
definitions.append({
    "type": "function",
    "function":{
        "name" : "get_group_sales",
        "description": """
            Groups total sales value by either country, customer or product
            
            Use this tool when the user asks for the total sales figures  
            for example:  
            - top 5 countries by turnover
            - which customer has the lowest sales?
            - what is the lowest selling product?
            
            Returns: a list of pairs group , total sales
        """,
        "parameters" : {
            "type" : "object",
            "properties" : {
                "group" : {
                    "type" : "string",
                    "enum" : ["country","customer","product"],
                    "description": " the column to group by"
                },
                "reverse" : {
                    "type" : "boolean",
                    "description": "optional, whether to order the results in ascending order, default is descending"
                },
                "limit" : {
                    "type" : "integer",
                    "description": "optional, the maximum number of results to return, return all rows otherwise"
                }
            },
            "required" : ["group"]
        }
    }
})
def get_group_sales(group: str, reverse: Optional[bool] = False, limit: Optional[int] = None) -> list[dict]:
    column = ""
    match group:
        case "country":
            column = "COUNTRY"
        case "customer":
            column = "CUSTOMERNAME"
        case "product":
            column = "PRODUCTCODE"
        case _:
             raise Exception("invalid value for group")

    query = \
        f"""
        SELECT {column}, sum(sales) as total
        FROM sales
        group by {column}
        order by total {"asc" if reverse else "desc"}
        {"limit " + str(limit) if limit else ""}
        ;
        """

    conn = sqlite3.connect(DB_URL)
    cursor = conn.cursor()
    cursor.execute(query)
    results = []
    for column, total_sales in cursor:
        results.append({"group": column, "total_sales": total_sales})
    return results
tools["get_group_sales"] = get_group_sales


# find_customers definition
definitions.append({
    "type": "function",
    "function":{
        "name" : "find_customers",
        "description": """
            returns a list of all customers whose name contains the provided string
        """,
        "parameters" : {
            "type" : "object",
            "properties" : {
                "name" : {
                    "type" : "string",
                    "description": "name or part of the name to filter by"
                }
            },
            "required" : ["name"]
        }
    }
})
def find_customers(name: str) -> list[str]:
    query = \
    f"""
    select distinct CUSTOMERNAME
    from sales
    where CUSTOMERNAME like ?
    """

    name = f"%{name}%"

    conn = sqlite3.connect(DB_URL)
    cursor = conn.cursor()
    cursor.execute(query, (name,))

    results = list()
    for row in cursor:
        results.append(row[0])

    return results
tools["find_customers"] = find_customers


# search_order_by_ordernumber definition
definitions.append({
    "type": "function",
    "function":{
        "name" : "search_order_by_ordernumber",
        "description": """
            Returns the order matching the provided ORDERNUMBER.

            Use this tool when the user asks for a specific order by number.

            Returns: a single object containing the matching row if an order is found, otherwise an empty object.
        """,
        "parameters" : {
            "type" : "object",
            "properties" : {
                "ordernumber" : {
                    "type" : "integer",
                    "description": "the order number to search for"
                }
            },
            "required" : ["ordernumber"]
        }
    }
})
def search_order_by_ordernumber(ordernumber: int) -> dict:
    query = """
    select
        ORDERNUMBER,
        QUANTITYORDERED,
        PRICEEACH,
        ORDERLINENUMBER,
        SALES,
        ORDERDATE,
        STATUS,
        QTR_ID,
        MONTH_ID,
        YEAR_ID,
        PRODUCTLINE,
        MSRP,
        PRODUCTCODE,
        CUSTOMERNAME,
        PHONE,
        ADDRESSLINE1,
        ADDRESSLINE2,
        CITY,
        STATE,
        POSTALCODE,
        COUNTRY,
        TERRITORY,
        CONTACTLASTNAME,
        CONTACTFIRSTNAME,
        DEALSIZE
    from sales
    where ORDERNUMBER = ?
    """

    conn = sqlite3.connect(DB_URL)
    cursor = conn.cursor()
    cursor.execute(query, (ordernumber,))

    columns = [description[0] for description in cursor.description]
    row = cursor.fetchone()

    if row is None:
        return {}

    return {column: value for column, value in zip(columns, row)}
tools["search_order_by_ordernumber"] = search_order_by_ordernumber


# find_ordernumbers_by_status definition
definitions.append({
    "type": "function",
    "function":{
        "name" : "find_orders_by_status",
        "description": """
            Returns all order numbers for a given order status.

            Use this tool when the user asks for orders in a specific status.

            Returns: a list of integers containing all matching ORDERNUMBER values.
        """,
        "parameters" : {
            "type" : "object",
            "properties" : {
                "status" : {
                    "type" : "string",
                    "enum" : ["Shipped", "Disputed", "In Process", "Cancelled", "On Hold", "Resolved"],
                    "description": "the order status to filter by"
                }
            },
            "required" : ["status"]
        }
    }
})
def find_orders_by_status(status: str) -> list[int]:
    allowed_statuses = {"Shipped", "Disputed", "In Process", "Cancelled", "On Hold", "Resolved"}
    if status not in allowed_statuses:
        raise Exception("invalid value for status")

    query = """
    select ORDERNUMBER
    from sales
    where STATUS = ?
    """

    conn = sqlite3.connect(DB_URL)
    cursor = conn.cursor()
    cursor.execute(query, (status,))

    results = list()
    for row in cursor:
        results.append(row[0])

    return results
tools["find_orders_by_status"] = find_orders_by_status


# get_sales_by_time_group definition
definitions.append({
    "type": "function",
    "function":{
        "name" : "get_sales_by_time",
        "description": """
            Groups total sales by year or by month.

            Use this tool when the user asks for sales trends over time.
            When grouping by month, months from different years stay separated.

            Returns: a list of dictionaries with the grouped time fields and total sales.
        """,
        "parameters" : {
            "type" : "object",
            "properties" : {
                "group" : {
                    "type" : "string",
                    "enum" : ["year", "month"],
                    "description": "choose whether to group by year or by month"
                },
                "limit" : {
                    "type" : "integer",
                    "description": "optional, the maximum number of grouped rows to return"
                }
            },
            "required" : ["group"]
        }
    }
})
def get_sales_by_time(group: str, limit: Optional[int] = None) -> list[dict]:
    if group == "year":
        query = """
        SELECT YEAR_ID, SUM(SALES) AS total_sales
        FROM sales
        GROUP BY YEAR_ID
        ORDER BY YEAR_ID DESC
        """
    elif group == "month":
        query = """
        SELECT MONTH_ID, YEAR_ID, SUM(SALES) AS total_sales
        FROM sales
        GROUP BY MONTH_ID, YEAR_ID
        ORDER BY YEAR_ID DESC, MONTH_ID DESC
        """
    else:
        raise Exception("invalid value for group")

    if limit is not None:
        query += "\n        LIMIT ?"

    conn = sqlite3.connect(DB_URL)
    cursor = conn.cursor()
    cursor.execute(query, (limit,) if limit is not None else ())

    results = list()
    if group == "year":
        for year_id, total_sales in cursor:
            results.append({"year": year_id, "total_sales": total_sales})
    else:
        for month_id, year_id, total_sales in cursor:
            results.append({"month": month_id, "year": year_id, "total_sales": total_sales})

    return results
tools["get_sales_by_time"] = get_sales_by_time


# get_quarterly_sales definition
definitions.append({
    "type": "function",
    "function":{
        "name" : "get_quarterly_sales",
        "description": """
            Groups total sales by quarter, keeping quarters from different years separated.

            Use this tool when the user asks for quarterly sales performance.

            Returns: a list of objects with quarter, year and total sales.
        """,
        "parameters" : {
            "type" : "object",
            "properties" : {
                "limit" : {
                    "type" : "integer",
                    "description": "optional, the maximum number of grouped rows to return"
                }
            }
        }
    }
})
def get_quarterly_sales(limit: Optional[int] = None) -> list[dict]:
    query = """
    SELECT QTR_ID, YEAR_ID, SUM(SALES) AS total_sales
    FROM sales
    GROUP BY QTR_ID, YEAR_ID
    ORDER BY YEAR_ID DESC, QTR_ID DESC
    """

    if limit is not None:
        query += "\n    LIMIT ?"

    conn = sqlite3.connect(DB_URL)
    cursor = conn.cursor()
    cursor.execute(query, (limit,) if limit is not None else ())

    results = list()
    for quarter_id, year_id, total_sales in cursor:
        results.append({"quarter": quarter_id, "year": year_id, "total_sales": total_sales})

    return results
tools["get_quarterly_sales"] = get_quarterly_sales


# "Qual è il fatturato totale per paese?"

# "Chi sono i top 5 clienti per volume di acquisti?"

# "Mostrami i prodotti più venduti" 

# "In quale trimestre abbiamo avuto le migliori performance di vendita?"

