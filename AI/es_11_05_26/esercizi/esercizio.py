from ChatModel import ChatModel

# temp / Top-p

# Chain-of-thought

# System

# role prompting

# CONTEXT
# INSTRUCTIONS
# INPUT
# OUTPUT

'''
□ RUOLO       Il modello sa chi deve essere?
□ CONTESTO    Ha tutte le informazioni necessarie?
□ TASK        L'istruzione è chiara e univoca?
□ FORMATO     L'output atteso è specificato?
□ LUNGHEZZA   C'è un vincolo di lunghezza?
□ TONO        Lo stile comunicativo è definito?
□ ESEMPI      Servono esempi per chiarire il pattern?
□ VINCOLI     Cosa NON deve fare il modello?
'''

chat = ChatModel()

prompt = \
"""
## CONTEXT
you are an expert with 15 years of experience in logistics

## INSTRUCTIONS
you'll receive a set of delivery orders for the day in CSV format  
you must plant the optimal delivery plan following the following constraints:
- truck number: 3
- truck max load: 150 Kg
- driver cost: 18 €/hour
- high priorities must be delivered within 2 hours
- delivery time accounts for round trip

prepare the plan step by step

## OUTPUT
output must be a JSON with the following structure:
| field | type | Description |
|---|---|---|
| `truck_id` | integer | truck identifier |
| `deliveries` | string array | Es. `["C002", "C005"]` — with optimal sequence |
| `total_weight_kg` | number | total weight in kilos |
| `total_distance_km` | number | total distance traveled in kilometers |
| `total_time_minutes` | integer | total travel time in minutes |
| `fuel_cost_euro` | number | `total_distance_km * 0.80` |
| `driver_cost_euro` | number | `(total_time_minutes / 60) * 18` |
| `total_cost_euro` | number | sum of all expenses |

## INPUT
|Customer_id|Customer_name|weight_kg|distance_km|time_minutes|priority|
|---|---|---|---|---|---|
C001|Customer A|85|15|45|standard
C002|Customer B|120|22|60|high
C003|Customer C|65|8|30|standard
C004|Customer D|95|18|50|high
C005|Customer E|55|12|40|standard
C006|Customer F|70|25|75|standard
"""
schema = {
  "type": "object",
  "additionalProperties": False,
  "properties": {
    "truck_plans": {
      "type": "array",
      "description": "Delivery plans for all trucks",
      "minItems": 3,
      "maxItems": 3,
      "items": {
        "type": "object",
        "additionalProperties": False,
        "properties": {
          "truck_id": {
            "type": "integer",
            "description": "Truck identifier"
          },
          "deliveries": {
            "type": "array",
            "description": "Optimal delivery sequence",
            "items": {
              "type": "string",
              "description": "Customer id such as C002"
            }
          },
          "total_weight_kg": {
            "type": "number",
            "description": "Total weight in kilos"
          },
          "total_distance_km": {
            "type": "number",
            "description": "Total distance traveled in kilometers"
          },
          "total_time_minutes": {
            "type": "integer",
            "description": "Total travel time in minutes"
          },
          "fuel_cost_euro": {
            "type": "number",
            "description": "total_distance_km * 0.80"
          },
          "driver_cost_euro": {
            "type": "number",
            "description": "(total_time_minutes / 60) * 18"
          },
          "total_cost_euro": {
            "type": "number",
            "description": "Sum of all expenses"
          }
        },
        "required": [
          "truck_id",
          "deliveries",
          "total_weight_kg",
          "total_distance_km",
          "total_time_minutes",
          "fuel_cost_euro",
          "driver_cost_euro",
          "total_cost_euro"
        ]
      }
    }
  },
  "required": ["truck_plans"]
}


copilot_system  =\
"""
You are a logistics expert with 15 years of experience.

Your task is to plan daily deliveries by assigning customers to the 3 available vans in the most efficient way possible, while respecting all operational constraints.

Operational rules:
- 3 vans available
- Maximum capacity per van: 150 kg
- Fuel cost: 0.80 euro per km
- Driver cost: 18 euro per hour
- Travel time includes the round trip to and from the depot
- Customers with high priority must be served within the first 2 hours

You must reason step by step internally before producing the final answer.

Follow these steps:
1. Read the input CSV carefully.
2. Identify the customers, their weights, distances, times, and priorities.
3. Check which customers have high priority.
4. Assign deliveries to the 3 vans so that:
   - no van exceeds 150 kg
   - high-priority customers are scheduled first
   - the delivery order is logically optimal
5. Compute for each van:
   - total weight
   - total distance
   - total time
   - fuel cost
   - driver cost
   - total cost
6. Verify that the final plan respects all constraints.
7. Return only the final JSON object.

Important rules:
- Do not show your internal reasoning.
- Do not output explanations, markdown, or code fences.
- Return only valid JSON.
- The JSON must strictly follow the required schema.
- Round monetary values to 2 decimal places.
- The top-level key must be delivery_plan.

Example of a valid delivery sequence:
- If a van serves customers C002 and C005, the deliveries array should preserve the best sequence, for example:
  ["C002", "C005"]

Example of cost calculation:
- If total_distance_km = 20, then fuel_cost_euro = 20 * 0.80 = 16.00
- If total_time_minutes = 90, then driver_cost_euro = (90 / 60) * 18 = 27.00

Example of expected JSON structure:
{
  "delivery_plan": [
    {
      "van_id": 1,
      "deliveries": ["C002", "C005"],
      "total_weight_kg": 175,
      "total_distance_km": 34.0,
      "total_time_minutes": 100,
      "fuel_cost_euro": 27.20,
      "driver_cost_euro": 30.00,
      "total_cost_euro": 57.20
    }
  ]
}

Use this exact structure for the final answer, with one object per van.
"""

copilot_prompt = \
"""
Here is the delivery data in CSV format:

customer_id,customer_name,weight_kg,distance_km,time_minutes,priority
C001,Customer A,85,15,45,standard
C002,Customer B,120,22,60,high
C003,Customer C,65,8,30,standard
C004,Customer D,95,18,50,high
C005,Customer E,55,12,40,standard
C006,Customer F,70,25,75,standard

Generate an optimal delivery plan for the 3 available vans.

Respond only with valid JSON that conforms to the schema.
"""

copilot_schema = \
{
  "type": "object",
  "additionalProperties": False,
  "properties": {
    "delivery_plan": {
      "type": "array",
      "description": "Delivery plans for all vans",
      "minItems": 3,
      "maxItems": 3,
      "items": {
        "type": "object",
        "additionalProperties": False,
        "properties": {
          "van_id": {
            "type": "integer",
            "description": "Van identifier"
          },
          "deliveries": {
            "type": "array",
            "description": "Optimal delivery sequence",
            "items": {
              "type": "string",
              "description": "Customer ID such as C002"
            }
          },
          "total_weight_kg": {
            "type": "number",
            "description": "Sum of assigned weights"
          },
          "total_distance_km": {
            "type": "number",
            "description": "Total distance traveled"
          },
          "total_time_minutes": {
            "type": "integer",
            "description": "Estimated total time"
          },
          "fuel_cost_euro": {
            "type": "number",
            "description": "total_distance_km * 0.80"
          },
          "driver_cost_euro": {
            "type": "number",
            "description": "(total_time_minutes / 60) * 18"
          },
          "total_cost_euro": {
            "type": "number",
            "description": "Sum of the two costs"
          }
        },
        "required": [
          "van_id",
          "deliveries",
          "total_weight_kg",
          "total_distance_km",
          "total_time_minutes",
          "fuel_cost_euro",
          "driver_cost_euro",
          "total_cost_euro"
        ]
      }
    }
  },
  "required": ["delivery_plan"]
}


print(chat.complete_structured(copilot_prompt,copilot_schema, copilot_system))
