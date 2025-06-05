const db = require('../db');
const Task = require('../models/Task');

class TaskDAO {
  static async create(title, description, start_date, end_date, status, project_id, assignee_id) {
    const [res] = await db.execute(
      `INSERT INTO Tasks (title, description, start_date, end_date, status, project_id, assignee_id)
       VALUES (?, ?, ?, ?, ?, ?, ?)`,
      [title, description, start_date, end_date, status, project_id, assignee_id]
    );
    return new Task(res.insertId, title, description, start_date, end_date, status, project_id, assignee_id);
  }
}

module.exports = TaskDAO;
