-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema zeroGlutenDatabase
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `zeroGlutenDatabase` ;

-- -----------------------------------------------------
-- Schema zeroGlutenDatabase
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `zeroGlutenDatabase` DEFAULT CHARACTER SET utf8 ;
USE `zeroGlutenDatabase` ;

-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT,
  `nombreUsuario` VARCHAR(50) NOT NULL,
  `primerApellido` VARCHAR(100) NULL,
  `email` VARCHAR(150) NULL,
  `password` VARCHAR(100) NULL,
  `fecha_nacimiento` DATE NULL,
  `sexo` VARCHAR(10) NULL,
  PRIMARY KEY (`idUsuario`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC) VISIBLE,
  UNIQUE INDEX `nombreUsuario_UNIQUE` (`nombreUsuario` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`alergia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`alergia` (
  `idAlergia` INT NOT NULL AUTO_INCREMENT,
  `nombreAlergia` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idAlergia`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`producto` (
  `idProducto` INT NOT NULL AUTO_INCREMENT,
  `nombreProducto` VARCHAR(50) NOT NULL,
  `urlImagen` VARCHAR(2100) NOT NULL,
  `contieneGluten` TINYINT NOT NULL,
  `precioProducto` DOUBLE NOT NULL,
  PRIMARY KEY (`idProducto`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`tipoProducto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`tipoProducto` (
  `nombreTipoProducto` VARCHAR(50) NOT NULL,
  `idProducto` INT NOT NULL,
  INDEX `fk_tipoProducto_producto1_idx` (`idProducto` ASC) VISIBLE,
  PRIMARY KEY (`idProducto`, `nombreTipoProducto`),
  CONSTRAINT `fk_tipoProducto_producto1`
    FOREIGN KEY (`idProducto`)
    REFERENCES `zeroGlutenDatabase`.`producto` (`idProducto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`receta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`receta` (
  `idReceta` INT NOT NULL AUTO_INCREMENT,
  `nombreReceta` VARCHAR(150) NOT NULL,
  `tiempoPreparacion` INT NOT NULL,
  `urlImagen` VARCHAR(75) NOT NULL,
  `descripcion` VARCHAR(200) NOT NULL,
  `vegetariano` TINYINT NOT NULL,
  `vegano` TINYINT NOT NULL,
  `sinGluten` TINYINT NOT NULL,
  `instrucciones` VARCHAR(2000) NOT NULL,
  `calorias` DOUBLE NOT NULL,
  PRIMARY KEY (`idReceta`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`receta_producto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`receta_producto` (
  `idProducto` INT NOT NULL,
  `idReceta` INT NOT NULL,
  `cantidad` INT NULL,
  PRIMARY KEY (`idProducto`, `idReceta`),
  INDEX `fk_producto_has_receta_receta1_idx` (`idReceta` ASC) VISIBLE,
  INDEX `fk_producto_has_receta_producto_idx` (`idProducto` ASC) VISIBLE,
  CONSTRAINT `fk_producto_has_receta_producto`
    FOREIGN KEY (`idProducto`)
    REFERENCES `zeroGlutenDatabase`.`producto` (`idProducto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_producto_has_receta_receta1`
    FOREIGN KEY (`idReceta`)
    REFERENCES `zeroGlutenDatabase`.`receta` (`idReceta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`perfil`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`perfil` (
  `idPerfil` INT NOT NULL AUTO_INCREMENT,
  `peso` DOUBLE NULL,
  `altura` DOUBLE NULL,
  `actividadFisica` TINYINT NULL,
  `frecuenciaActividadFisica` VARCHAR(45) NULL,
  `condicionMedica` VARCHAR(50) NULL,
  `medicacion` TINYINT NULL,
  `puntuacionAlimentacion` VARCHAR(45) NULL,
  `fumador` TINYINT NULL,
  `enfermedades` VARCHAR(100) NULL,
  `intolerancias` VARCHAR(70) NULL,
  `tipoDieta` VARCHAR(100) NULL,
  `idUsuario` INT NOT NULL,
  PRIMARY KEY (`idPerfil`, `idUsuario`),
  INDEX `fk_perfil_usuario1_idx` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_perfil_usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `zeroGlutenDatabase`.`usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`usuario_alergia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`usuario_alergia` (
  `idUsuario` INT NOT NULL,
  `idAlergia` INT NOT NULL,
  PRIMARY KEY (`idUsuario`, `idAlergia`),
  INDEX `fk_usuario_has_alergia_alergia1_idx` (`idAlergia` ASC) VISIBLE,
  INDEX `fk_usuario_has_alergia_usuario1_idx` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_usuario_has_alergia_usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `zeroGlutenDatabase`.`usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_usuario_has_alergia_alergia1`
    FOREIGN KEY (`idAlergia`)
    REFERENCES `zeroGlutenDatabase`.`alergia` (`idAlergia`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `zeroGlutenDatabase`.`recetasFavoritas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `zeroGlutenDatabase`.`recetasFavoritas` (
  `idReceta` INT NOT NULL,
  `idUsuario` INT NOT NULL,
  `fechaGuardado` DATE NULL,
  PRIMARY KEY (`idReceta`, `idUsuario`),
  INDEX `fk_receta_has_usuario_usuario1_idx` (`idUsuario` ASC) VISIBLE,
  INDEX `fk_receta_has_usuario_receta1_idx` (`idReceta` ASC) VISIBLE,
  CONSTRAINT `fk_receta_has_usuario_receta1`
    FOREIGN KEY (`idReceta`)
    REFERENCES `zeroGlutenDatabase`.`receta` (`idReceta`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_receta_has_usuario_usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `zeroGlutenDatabase`.`usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
