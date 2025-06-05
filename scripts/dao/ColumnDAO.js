const db = require('../db');
const Column = require('../models/Column');

class ColumnDAO {
  static async create(title, board_id, order) {
    const [res] = await db.execute(
      'INSERT INTO `Columns` (title, board_id, `order`) VALUES (?, ?, ?)',
      [title, board_id, order]
    );
    return new Column(res.insertId, title, board_id, order);
  }
}

module.exports = ColumnDAO;
