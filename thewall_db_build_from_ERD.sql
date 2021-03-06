-- MySQL Script generated by MySQL Workbench
-- Tue Aug 15 16:06:20 2017
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema TheWall
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema TheWall
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `TheWall` DEFAULT CHARACTER SET utf8 ;
USE `TheWall` ;

-- -----------------------------------------------------
-- Table `TheWall`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TheWall`.`users` ;

CREATE TABLE IF NOT EXISTS `TheWall`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(255) NULL,
  `LastName` VARCHAR(255) NULL,
  `Email` VARCHAR(255) NULL,
  `UserName` VARCHAR(255) NULL,
  `Password` VARCHAR(255) NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = '					';


-- -----------------------------------------------------
-- Table `TheWall`.`messages`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TheWall`.`messages` ;

CREATE TABLE IF NOT EXISTS `TheWall`.`messages` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `message` TEXT NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`, `user_id`),
  INDEX `fk_messages_users_idx` (`user_id` ASC),
  CONSTRAINT `fk_messages_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `TheWall`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TheWall`.`comments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TheWall`.`comments` ;

CREATE TABLE IF NOT EXISTS `TheWall`.`comments` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `comment` TEXT NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  `message_id` INT NOT NULL,
  `user_id` INT NOT NULL,
  PRIMARY KEY (`id`, `message_id`, `user_id`),
  INDEX `fk_comments_messages1_idx` (`message_id` ASC),
  INDEX `fk_comments_users1_idx` (`user_id` ASC),
  CONSTRAINT `fk_comments_messages1`
    FOREIGN KEY (`message_id`)
    REFERENCES `TheWall`.`messages` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_comments_users1`
    FOREIGN KEY (`user_id`)
    REFERENCES `TheWall`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
