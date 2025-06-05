class Task {
  constructor(id, title, description, start_date, end_date, status, project_id, assignee_id) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.start_date = start_date;
    this.end_date = end_date;
    this.status = status;
    this.project_id = project_id;
    this.assignee_id = assignee_id;
  }
}
module.exports = Task;
