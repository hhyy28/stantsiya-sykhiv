const db = require('../db');
const User = require('../models/User');

class UserDAO {
  static async create(username, email, passwordHash) {
    const [res] = await db.execute(
      'INSERT INTO Users (username, email, passwordHash) VALUES (?, ?, ?)',
      [username, email, passwordHash]
    );
    return new User(res.insertId, username, email, passwordHash);
  }

  static async getById(id) {
    const [rows] = await db.execute('SELECT * FROM Users WHERE id = ?', [id]);
    if (!rows.length) return null;
    const { id: uid, username, email, passwordHash } = rows[0];
    return new User(uid, username, email, passwordHash);
  }

  static async getAll() {
    const [rows] = await db.execute('SELECT * FROM Users');
    return rows.map(r => new User(r.id, r.username, r.email, r.passwordHash));
  }
}

module.exports = UserDAO;
