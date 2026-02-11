import os
#file format:
# key_1#type = id, key_2#type     , ...
# value_1   , value_2   , ...

#dict format:
#{
# value_1:{
#   key_2:value_2,
#   ...
#    }
# value_1(row_2):{
#   key_2: value_2(row_2)
#}}

#how to know when value is int / float? in column name?
def read_csv(file_name:str):
    if not os.path.exists(file_name):
        return True
    with open(file_name, "r") as file:
        csv = dict()
        #first line is keys
        keys = file.readline().strip().split(",")[1:] #discard first as it's always ID
        for line in file:
            row = line.strip().split(",")
            #first element is ID
            id = row.pop(0)
            csv[id] = dict()
            for i in range(len(keys)):
                csv[id][keys[i]] = row[i]
    return csv




def write_csv(file_name:str, data:dict, keys:function = lambda x: x.keys):
    #if keys is provided use it to determine in which order to write to file
    #write first line with the dictionary keys
    #write all values to file
    pass

def append_csv():
    #accept keys as argument to determine order or read first line?
    pass


test_dict = {
    1:{"nome":"Samuele","cognome":"Querio"},
    2:{"nome":"Manuel","cognome":"Frola"}
}

read_csv("./DB_libri.txt")