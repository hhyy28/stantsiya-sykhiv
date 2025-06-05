-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema TaskManagementSystem
-- -----------------------------------------------------

DROP SCHEMA IF EXISTS `TaskManagementSystem`;
CREATE SCHEMA IF NOT EXISTS `TaskManagementSystem` DEFAULT CHARACTER SET utf8;
USE `TaskManagementSystem`;

-- -----------------------------------------------------
-- Table `Users`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `Users`;
CREATE TABLE IF NOT EXISTS `Users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(100) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `passwordHash` TEXT NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `username_UNIQUE` (`username` ASC),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC)
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Projects`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `Projects`;
CREATE TABLE IF NOT EXISTS `Projects` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `description` TEXT NULL,
  `owner_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Projects_Users_idx` (`owner_id` ASC),
  CONSTRAINT `fk_Projects_Users`
    FOREIGN KEY (`owner_id`)
    REFERENCES `Users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Boards`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `Boards`;
CREATE TABLE IF NOT EXISTS `Boards` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `project_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Boards_Projects_idx` (`project_id` ASC),
  CONSTRAINT `fk_Boards_Projects`
    FOREIGN KEY (`project_id`)
    REFERENCES `Projects` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Columns`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `Columns`;
CREATE TABLE IF NOT EXISTS `Columns` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `board_id` INT NOT NULL,
  `order` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Columns_Boards_idx` (`board_id` ASC),
  CONSTRAINT `fk_Columns_Boards`
    FOREIGN KEY (`board_id`)
    REFERENCES `Boards` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Tasks`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `Tasks`;
CREATE TABLE IF NOT EXISTS `Tasks` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `title` TEXT NOT NULL,
  `description` TEXT NULL,
  `start_date` DATE NULL,
  `end_date` DATE NULL,
  `status` TEXT NOT NULL,
  `project_id` INT NOT NULL,
  `assignee_id` INT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Tasks_Projects_idx` (`project_id` ASC),
  INDEX `fk_Tasks_Users_idx` (`assignee_id` ASC),
  CONSTRAINT `fk_Tasks_Projects`
    FOREIGN KEY (`project_id`)
    REFERENCES `Projects` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Tasks_Users`
    FOREIGN KEY (`assignee_id`)
    REFERENCES `Users` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `TaskColumnLinks`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `TaskColumnLinks`;
CREATE TABLE IF NOT EXISTS `TaskColumnLinks` (
  `task_id` INT NOT NULL,
  `column_id` INT NOT NULL,
  PRIMARY KEY (`task_id`, `column_id`),
  INDEX `fk_TaskColumnLinks_Tasks_idx` (`task_id` ASC),
  INDEX `fk_TaskColumnLinks_Columns_idx` (`column_id` ASC),
  CONSTRAINT `fk_TaskColumnLinks_Tasks`
    FOREIGN KEY (`task_id`)
    REFERENCES `Tasks` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_TaskColumnLinks_Columns`
    FOREIGN KEY (`column_id`)
    REFERENCES `Columns` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `Comments`
-- -----------------------------------------------------

DROP TABLE IF EXISTS `Comments`;
CREATE TABLE IF NOT EXISTS `Comments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `task_id` INT NOT NULL,
  `author_id` INT NOT NULL,
  `content` TEXT NOT NULL,
  `timestamp` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Comments_Tasks_idx` (`task_id` ASC),
  INDEX `fk_Comments_Users_idx` (`author_id` ASC),
  CONSTRAINT `fk_Comments_Tasks`
    FOREIGN KEY (`task_id`)
    REFERENCES `Tasks` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Comments_Users`
    FOREIGN KEY (`author_id`)
    REFERENCES `Users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
) ENGINE = InnoDB;

-- -----------------------------------------------------
-- Restore original settings
-- -----------------------------------------------------

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;