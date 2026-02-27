from entity.Registration import Registration
from payload.RegistrationResponse import RegistrationResponse
import sqlite3

class RegistrationRepository:
    @staticmethod
    def save(registration):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()

        cursor.execute('''INSERT INTO registrations (data, user_id, course_id)
                          values (?, ?, ?)''',
                       (registration.data, registration.user_id, registration.course_id))
        count_row = cursor.rowcount
        conn.commit()
        conn.close()
        return count_row

    @staticmethod
    def delete_registration(registration):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''DELETE FROM registrations WHERE id = ?''', (registration.id,))
        if cursor.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True

    @staticmethod
    def delete_by_course(course):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute("DELETE FROM registrations WHERE course_id = ?", (course.id,))
        if cursor.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True

    @staticmethod
    def find_registration_by_id(registration_id):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT * FROM registrations WHERE id = ?''', (registration_id,))
        row = cursor.fetchone()
        if not row: return None
        conn.close()
        registration = Registration(row[0], row[1], row[2], row[3])
        return registration

    @staticmethod
    def exists_registration_by_user_id_and_course_id(user, course):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT count(*) FROM registrations WHERE user_id = ? and course_id = ?''', (user.id, course.id))
        count = cursor.fetchone()[0]
        conn.close()
        return count > 0

    @staticmethod
    def find_all_registrations():
        list_registration_response = []
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT registrations.id, registrations.data, users.name, users.lastname, users.subscription_state, courses.name  
                        FROM registrations
                        JOIN users ON users.id = registrations.user_id
                        JOIN Courses ON Courses.id = registrations.course_id
                       ''')
        rows = cursor.fetchall()
        for row in rows:
            list_registration_response.append(RegistrationResponse(row[0], row[1], row[2], row[3], row[4], row[5]))
        conn.close()
        return list_registration_response

    @staticmethod
    def delete_by_user_id(user):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''DELETE FROM registrations WHERE user_id = ?''', (user.id,))
        if cursor.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True

    @staticmethod
    def find_all_by_user_id(user):
        listRegistrations = []
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT * FROM registrations WHERE user_id = ?''', (user.id,))
        rows = cursor.fetchall()
        for row in rows:
            listRegistrations.append(Registration(row[0], row[1], row[2], row[3]))
        conn.close()
        return listRegistrations