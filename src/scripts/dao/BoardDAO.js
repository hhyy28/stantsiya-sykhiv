const db = require('../db');
const Board = require('../models/Board');

class BoardDAO {
  static async create(title, project_id) {
    const [res] = await db.execute(
      'INSERT INTO Boards (title, project_id) VALUES (?, ?)',
      [title, project_id]
    );
    return new Board(res.insertId, title, project_id);
  }

  static async getAll() {
    const [rows] = await db.execute('SELECT * FROM Boards');
    return rows.map(r => new Board(r.id, r.title, r.project_id));
  }
}

module.exports = BoardDAO;
