def fn(obj_dict):
	def fn1():
		return obj_dict["value"]
	return fn1
	
dizionario = dict()
dizionario["value"] = "ciao"
dizionario["fn"] = fn(dizionario)


print(dizionario["fn"]())
