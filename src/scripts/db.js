const mysql = require('mysql2/promise');

const pool = mysql.createPool({
  host: 'localhost',
  user: 'root',
  password: '1111', 
  database: 'TaskManagementSystem',
});

module.exports = pool;
