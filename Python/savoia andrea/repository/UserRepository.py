import sqlite3
from entity.User import User

# Repository layer: raw SQL access for users.
class UserRepository:

    @staticmethod
    def save(user):
        # Insert a new user record.
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()

        cursor.execute('''INSERT INTO users (name, lastname, subscription_state)
                          values (?, ?, ?)''',
                       (user.name, user.lastname, user.subscription_state,))
        count_row = cursor.rowcount
        conn.commit()
        conn.close()
        return count_row

    @staticmethod
    def find_all_users():
        # Retrieve all users.
        users_list = []
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT * FROM users''')
        rows = cursor.fetchall()
        for row in rows:
            users_list.append(User(row[0], row[1], row[2], row[3]))
        conn.close()
        return users_list

    @staticmethod
    def find_user_by_id(user_id):
        # Fetch a single user by id.
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''SELECT * FROM users WHERE id = ?''', (user_id,))
        row = cursor.fetchone()
        if not row: return None
        conn.close()
        user = User(row[0], row[1], row[2], row[3])
        return user

    @staticmethod
    def update_subscription_state(state, user_id):
        # Update the subscription flag.
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''UPDATE users SET subscription_state = ? WHERE id = ?''',
                          (state, user_id,))
        if cursor.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True

    @staticmethod
    def delete_user_by_id(user):
        conn = sqlite3.connect('./gym.sqlite')
        cursor = conn.cursor()
        cursor.execute('''DELETE FROM users WHERE id = ?''', (user.id,))
        if cursor.rowcount == 0:
            conn.rollback()
            conn.close()
            return False
        conn.commit()
        conn.close()
        return True