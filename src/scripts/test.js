const UserDAO = require('./dao/UserDAO');
const ProjectDAO = require('./dao/ProjectDAO');
const BoardDAO = require('./dao/BoardDAO');
const ColumnDAO = require('./dao/ColumnDAO');
const TaskDAO = require('./dao/TaskDAO');
const CommentDAO = require('./dao/CommentDAO');
const TaskColumnLinkDAO = require('./dao/TaskColumnLinkDAO');

(async () => {
  try {
    // Створення користувача
    const user = await UserDAO.create('test_user', 'test@example.com', '1234hash');
    console.log('Created user:', user);

    // Створення проєкту
    const project = await ProjectDAO.create('My Project', 'Test project description', user.id);
    console.log('Created project:', project);

    // Створення дошки
    const board = await BoardDAO.create('Main Board', project.id);
    console.log('Created board:', board);

    // Створення колонки
    const column = await ColumnDAO.create('To Do', board.id, 1);
    console.log('Created column:', column);

    // Створення завдання
    const task = await TaskDAO.create(
      'Implement feature',
      'Add DAO layer for boards',
      '2025-06-05',
      '2025-06-10',
      'pending',
      project.id,
      user.id
    );
    console.log('Created task:', task);

    // Прив’язка завдання до колонки
    const taskColumnLink = await TaskColumnLinkDAO.create(task.id, column.id);
    console.log('Created task-column link:', taskColumnLink);

    // Додавання коментаря
    const comment = await CommentDAO.create(
      task.id,
      user.id,
      'Please review the DAO layer',
      new Date().toISOString().slice(0, 19).replace('T', ' ')
    );
    console.log('Created comment:', comment);
  } catch (err) {
    console.error('Error:', err);
  }
})();
