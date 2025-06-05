const db = require('../db');
const Comment = require('../models/Comment');

class CommentDAO {
  static async create(task_id, author_id, content, timestamp) {
    const [res] = await db.execute(
      'INSERT INTO Comments (task_id, author_id, content, timestamp) VALUES (?, ?, ?, ?)',
      [task_id, author_id, content, timestamp]
    );
    return new Comment(res.insertId, task_id, author_id, content, timestamp);
  }
}

module.exports = CommentDAO;
