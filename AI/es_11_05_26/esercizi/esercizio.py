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

chat = ChatModel()
print(chat.complete(prompt))
