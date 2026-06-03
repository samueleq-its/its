import pandas, sqlite3

DB_URL = "./db/db.sqlite3"
CSV_URL = "./sales_data_sample.csv"

def import_csv(db_url, csv_url):
    conn = sqlite3.connect(db_url)
    data_frame = pandas.read_csv(csv_url, encoding="latin", index_col=0)
    data_frame.to_sql("sales", conn, if_exists='replace')
    conn.close()


import_csv(DB_URL, CSV_URL)