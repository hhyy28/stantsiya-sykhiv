const db = require('../db');
const TaskColumnLink = require('../models/TaskColumnLink');

class TaskColumnLinkDAO {
  static async create(task_id, column_id) {
    await db.execute(
      'INSERT INTO TaskColumnLinks (task_id, column_id) VALUES (?, ?)',
      [task_id, column_id]
    );
    return new TaskColumnLink(task_id, column_id);
  }
}

module.exports = TaskColumnLinkDAO;
