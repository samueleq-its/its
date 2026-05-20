import json
import requests

url = "http://127.0.0.1/php/Architetture%20IT/API"

# LOGIN
print("LOGIN")
print("TEST 1")
contents = requests.get(url=url).content
data = json.loads(contents)
print(data["success"] == False)


print("TEST 2")
contents = requests.get(url=url, params={"username":"boh", "password":"boh2"}).content
data = json.loads(contents)
print(data["success"] == False)


print("TEST 3")
contents = requests.get(url=url, params={"username":"admin", "password":"admin"}).content
data = json.loads(contents)
print(data["success"] == True)

print()


url += "/lista.php"

#LIST
print("LISTA")
print("TEST 1")
contents = requests.get(url=url, params={}).content
data = json.loads(contents)
print(data["success"] == False)

print("TEST 2")
contents = requests.get(url=url, params={"token":"asdads"}).content
data = json.loads(contents)
print(data["success"] == False)

print("TEST 3")
contents = requests.get(url=url, params={"token":"123"}).content
data = json.loads(contents)
print(data["success"] == True)