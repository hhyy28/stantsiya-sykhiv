const db = require('../db');
const Project = require('../models/Project');

class ProjectDAO {
  static async create(title, description, owner_id) {
    const [res] = await db.execute(
      'INSERT INTO Projects (title, description, owner_id) VALUES (?, ?, ?)',
      [title, description, owner_id]
    );
    return new Project(res.insertId, title, description, owner_id);
  }

  static async getAll() {
    const [rows] = await db.execute('SELECT * FROM Projects');
    return rows.map(r => new Project(r.id, r.title, r.description, r.owner_id));
  }
}

module.exports = ProjectDAO;
