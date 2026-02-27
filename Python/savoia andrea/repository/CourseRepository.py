from entity.Course import *
import sqlite3

class CourseRepository:
    @staticmethod
    def save(course):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()

        cursor.execute('''INSERT INTO courses (name, busy_places, max_places)
                          values (?, ?, ?)''',
                       (course.name, course.busy_places, course.max_places))
        count_row = cursor.rowcount
        conn.commit()
        conn.close()
        return count_row

    @staticmethod
    def update_busy_places(corse_id, delta):
        conn = sqlite3.connect('./gym.sqlite')
        cur = conn.cursor()
        cur.execute("UPDATE courses SET busy_places = busy_places + ? WHERE id = ?", (delta, corse_id,))
        if cur.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True

    @staticmethod
    def update_max_places(course, new_max_places):
        conn = sqlite3.connect('./gym.sqlite')
        cur = conn.cursor()
        cur.execute("UPDATE courses SET max_places = ? WHERE id = ?", (new_max_places, course.id,))
        if cur.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True

    @staticmethod
    def find_all_courses():
        courses_list = []
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT *
                          FROM courses''')
        rows = cursor.fetchall()
        for row in rows:
            courses_list.append(Course(row[0], row[1], row[2], row[3]))
        conn.close()
        return courses_list

    @staticmethod
    def find_course_by_name(course_name):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT *
                          FROM courses
                          WHERE name = ?''', (course_name,))
        row = cursor.fetchone()
        if not row: return None
        conn.close()
        course = Course(row[0], row[1], row[2], row[3])
        return course

    @staticmethod
    def find_busy_places(course):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT busy_places FROM courses WHERE id = ?''', (course.id,))
        busy_places = cursor.fetchone()[0]
        conn.close()
        return busy_places

    @staticmethod
    def delete_course(course):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''DELETE FROM courses WHERE id = ?''', (course.id,))
        if cursor.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True
