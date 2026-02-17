from db_handler import DB_Handler
from course import Course
from client import Client

#TODO: DB doesn't check if client or course exists
#TODO: change all id parameters into objects

class Subscription():

    def __init__(self, id_course:int, id_client:int,) -> None:
        self.id_course = id_course
        self.id_client = id_client

    #TODO: better names
    @classmethod
    def db_to_obj(cls, select:list) -> Subscription:
        return Subscription(
            select[0],
            select[1],
            )

    #doesn't check if client or course exists, or course has seats available
    @classmethod
    def add(cls, id_course:int, id_client:int) -> Subscription | None:
        crs = DB_Handler.get_cursor()
        #checks if subscription already exists
        if cls.exist(id_course, id_client):
            return None
        crs.execute ("INSERT INTO subscriptions(id_course, id_client) VALUES(?, ?)", (id_course, id_client))
        Course.find(id_course).occupy()
        DB_Handler.commit()
        crs.close()
        return Subscription(id_course, id_client)

    @classmethod
    def read(cls) -> list[Subscription]:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id_course, id_client FROM subscriptions;")
        results = crs.fetchall()
        crs.close()
        if results == None:
            return []
        subscriptions = list()
        for result in results:
            subscriptions.append(cls.db_to_obj(result))
        return subscriptions

    #TODO: find by client id, find by course id, 
    @classmethod
    def find(cls,id_course:int, id_client:int) -> Subscription:
        crs = DB_Handler.get_cursor()
        crs.execute("SELECT id_course, id_client FROM subscriptions WHERE id_course = ? AND id_client = ?;", (id_course, id_client))
        result = crs.fetchone()
        crs.close()
        if result == None:
            return Subscription(0,0)
        return cls.db_to_obj(result)
    
    @classmethod
    def exist(cls,id_course,id_client) -> bool:
        return cls.find(id_course, id_client).id_course != 0

    def delete(self):
        crs = DB_Handler.get_cursor()
        crs.execute("DELETE FROM subscriptions WHERE id_course = ? AND id_client=?;", (self.id_course,self.id_client))
        Course.find(self.id_course).release()
        DB_Handler.commit()
        crs.close()

    #TODO: remake with objects instead
    def to_string(self):
        course = Course.find(self.id_course)
        client = Client.find(self.id_client)
        return f"{course.name}, {client.to_string()}"
    
