class Comment {
  constructor(id, task_id, author_id, content, timestamp) {
    this.id = id;
    this.task_id = task_id;
    this.author_id = author_id;
    this.content = content;
    this.timestamp = timestamp;
  }
}
module.exports = Comment;
