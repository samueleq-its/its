from db_handler import DB_Handler

# IF course.id == 0 : course not found

class Course():

    def __init__(self, id:int, name:str, available:int) -> None:
        self.id = id
        self.name = name
        self.available = available

    #TODO: better names
    @classmethod
    def db_to_obj(cls, select:list) -> Course:
        return Course(
            select[0],
            select[1],
            select[2]
            )

    @classmethod
    def add(cls, name:str, available:int) -> Course:
        crs = DB_Handler.get_cursor()
        crs.execute ("INSERT INTO courses(name, available) VALUES(?, ?)", (name, available)) 
        added = cls.find(crs.lastrowid)
        DB_Handler.commit()
        crs.close()
        return added

    @classmethod
    def read(cls) -> list[Course]:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id, name, available FROM courses;")
        results = crs.fetchall()
        crs.close()
        if results == None:
            return []
        courses = list()
        for result in results:
            courses.append(cls.db_to_obj(result))
        return courses

    @classmethod
    def find(cls,id:int) -> Course:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id, name, available FROM courses WHERE id = ?;", (id,))
        result = crs.fetchone()
        crs.close()
        if result == None:
            return Course(0,"",0)
        return cls.db_to_obj(result)

    def set_available(self, new_available):
        crs = DB_Handler.get_cursor()
        crs.execute("UPDATE courses SET available = ? WHERE id = ?;", (new_available, self.id))
        self.available = new_available
        DB_Handler.commit()
        crs.close()

    def occupy(self) -> bool:
        self.set_available(self.available - 1)
        return True

    def release(self):
        self.set_available(self.available + 1)  

    def delete(self):
        crs = DB_Handler.get_cursor()
        crs.execute("DELETE FROM courses WHERE id = ?;", (self.id,))
        DB_Handler.commit()
        crs.close()

    def to_string(self):
        return f"{self.id}, {self.name}, {self.available}"
