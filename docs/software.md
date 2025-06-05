# Реалізація інформаційного та програмного забезпечення

### SQL-скрипт для створення на початкового наповнення бази даних:
```sql
-- -----------------------------------------------------
-- Set custom settings
-- -----------------------------------------------------
SET
  @old_unique_checks = IFNULL(@@unique_checks, 1),
  unique_checks = 0,
  @old_foreign_key_checks = IFNULL(@@foreign_key_checks, 1),
  foreign_key_checks = 0,
  @old_sql_mode = IFNULL(@@sql_mode, ''),
  sql_mode = 'TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema taskmanagementsystem
-- -----------------------------------------------------
DROP DATABASE IF EXISTS `taskmanagementsystem`;
CREATE DATABASE IF NOT EXISTS `taskmanagementsystem` DEFAULT CHARACTER SET utf8;
USE `taskmanagementsystem`;

-- -----------------------------------------------------
-- Tables
-- -----------------------------------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(100) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `password_hash` TEXT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `username_unique` (`username` ASC),
  UNIQUE INDEX `email_unique` (`email` ASC)
) ENGINE=InnoDB;

DROP TABLE IF EXISTS `project`;
CREATE TABLE IF NOT EXISTS `project` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `description` TEXT NULL,
  `owner_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_project_user_idx` (`owner_id` ASC),
  CONSTRAINT `fk_project_user`
    FOREIGN KEY (`owner_id`)
    REFERENCES `user` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB;

DROP TABLE IF EXISTS `board`;
CREATE TABLE IF NOT EXISTS `board` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `project_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_board_project_idx` (`project_id` ASC),
  CONSTRAINT `fk_board_project`
    FOREIGN KEY (`project_id`)
    REFERENCES `project` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB;

DROP TABLE IF EXISTS `column`;
CREATE TABLE IF NOT EXISTS `column` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `board_id` INT NOT NULL,
  `order` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_column_board_idx` (`board_id` ASC),
  CONSTRAINT `fk_column_board`
    FOREIGN KEY (`board_id`)
    REFERENCES `board` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB;

DROP TABLE IF EXISTS `task`;
CREATE TABLE IF NOT EXISTS `task` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `description` TEXT NULL,
  `start_date` DATE NULL,
  `end_date` DATE NULL,
  `status` TEXT NOT NULL,
  `project_id` INT NOT NULL,
  `assignee_id` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_task_project_idx` (`project_id` ASC),
  INDEX `fk_task_user_idx` (`assignee_id` ASC),
  CONSTRAINT `fk_task_project`
    FOREIGN KEY (`project_id`)
    REFERENCES `project` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_task_user`
    FOREIGN KEY (`assignee_id`)
    REFERENCES `user` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE=InnoDB;

DROP TABLE IF EXISTS `taskcolumnlink`;
CREATE TABLE IF NOT EXISTS `taskcolumnlink` (
  `task_id` INT NOT NULL,
  `column_id` INT NOT NULL,
  PRIMARY KEY (`task_id`, `column_id`),
  INDEX `fk_taskcolumnlink_task_idx` (`task_id` ASC),
  INDEX `fk_taskcolumnlink_column_idx` (`column_id` ASC),
  CONSTRAINT `fk_taskcolumnlink_task`
    FOREIGN KEY (`task_id`)
    REFERENCES `task` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_taskcolumnlink_column`
    FOREIGN KEY (`column_id`)
    REFERENCES `column` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB;

DROP TABLE IF EXISTS `comment`;
CREATE TABLE IF NOT EXISTS `comment` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `task_id` INT NOT NULL,
  `author_id` INT NOT NULL,
  `content` TEXT NOT NULL,
  `timestamp` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_comment_task_idx` (`task_id` ASC),
  INDEX `fk_comment_user_idx` (`author_id` ASC),
  CONSTRAINT `fk_comment_task`
    FOREIGN KEY (`task_id`)
    REFERENCES `task` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_comment_user`
    FOREIGN KEY (`author_id`)
    REFERENCES `user` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE=InnoDB;

-- -----------------------------------------------------
-- Restore original settings
-- -----------------------------------------------------
SET 
  sql_mode = @old_sql_mode,
  foreign_key_checks = @old_foreign_key_checks,
  unique_checks = @old_unique_checks;
```

### SQL-скрипт для заповнення
```sql
INSERT INTO `user` (id, username, email, passwordHash)
VALUES 
  (1, 'geyorgiy', 'geyorgi228@example.com', 'passwordHash'),
  (2, 'anna', 'anna@example.com', 'passwordHash2'),
  (3, 'mark', 'mark@example.com', 'passwordHash3');

INSERT INTO `project` (id, title, description, owner_id)
VALUES 
  (1, 'task management project', 'a project for managing tasks', 1),
  (2, 'website redesign', 'redesign company website', 2),
  (3, 'mobile app development', 'develop new mobile app', 3);

INSERT INTO `board` (id, title, project_id)
VALUES 
  (1, 'main board', 1),
  (2, 'redesign board', 2),
  (3, 'app dev board', 3);

INSERT INTO `column` (id, title, board_id, `order`)
VALUES 
  (1, 'to do', 1, 1),
  (2, 'in progress', 1, 2),
  (3, 'done', 1, 3),
  (4, 'backlog', 2, 1),
  (5, 'design', 2, 2),
  (6, 'testing', 3, 1);

INSERT INTO `task` (id, title, description, start_date, end_date, status, project_id, assignee_id)
VALUES 
  (1, 'set up project', 'initial setup of the project structure', '2025-05-20', NULL, 'to do', 1, 1),
  (2, 'create wireframes', 'design wireframes for homepage', '2025-05-21', '2025-05-25', 'in progress', 2, 2),
  (3, 'implement login', 'build login functionality', '2025-05-22', NULL, 'to do', 3, 3);

INSERT INTO `taskcolumnlink` (task_id, column_id)
VALUES 
  (1, 1),
  (2, 5),
  (3, 6);

INSERT INTO `comment` (id, task_id, author_id, content, timestamp)
VALUES 
  (1, 1, 1, 'do this', NOW()),
  (2, 2, 2, 'wireframes need review', NOW()),
  (3, 3, 3, 'login should be secure', NOW());
```
