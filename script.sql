DROP DATABASE vl_test;
CREATE DATABASE vl_test CHARACTER SET utf8 COLLATE utf8_general_ci;
USE vl_test;

CREATE TABLE `regiones` (
  `id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `codigo_reg` varchar(45) NULL,
  `index` varchar(45) NULL DEFAULT NULL,
  `nombre` varchar(45) NULL DEFAULT NULL,
  `costo_viaje` int(11) NOT NULL default '0',
  `taza_imprevisto` int(11) NOT NULL default '0'
);
INSERT INTO `regiones` values (NULL,'RM', '1', 'Región Metropolitana', 20000, 75000);
INSERT INTO `regiones` values (NULL,'15', '2', 'Arica y Parinacota', 0, 0);
INSERT INTO `regiones` values (NULL,'I', '3', 'Tarapacá', 0, 0);
INSERT INTO `regiones` values (NULL,'II', '4', 'Antofagasta', 0, 0);
INSERT INTO `regiones` values (NULL,'III', '5', 'Atacama', 0, 0);
INSERT INTO `regiones` values (NULL,'IV', '6', 'Coquimbo', 350000, 125000);
INSERT INTO `regiones` values (NULL,'V', '7', 'Valparaiso', 90000, 75000);
INSERT INTO `regiones` values (NULL,'VI', '8', 'O´Higgins', 0, 0);
INSERT INTO `regiones` values (NULL,'VII', '9', 'Maule', 0, 0);
INSERT INTO `regiones` values (NULL,'VIII', '10', 'Bio-Bio', 450000, 100000);
INSERT INTO `regiones` values (NULL,'IX', '11', 'Araucanía', 0, 0);
INSERT INTO `regiones` values (NULL,'XIV', '12', 'Los Rios', 0, 0);
INSERT INTO `regiones` values (NULL,'X', '13', 'Los Lagos', 550000, 150000);
INSERT INTO `regiones` values (NULL,'XI', '14', 'Aysén', 0, 0);
INSERT INTO `regiones` values (NULL,'XII', '15', 'Magallanes y Antartica', 0, 0);

CREATE TABLE `tipo_vidrio` (
  `id` int(11) AUTO_INCREMENT PRIMARY KEY,
  `nombre` varchar(45),
  `precio` int(11) not null default '0'
);
INSERT INTO `tipo_vidrio` VALUES (NULL, 'Lam 8', 11000);
INSERT INTO `tipo_vidrio` VALUES (NULL, 'Lam 10', 14000);
INSERT INTO `tipo_vidrio` VALUES (NULL, 'Lam 12', 18000);
INSERT INTO `tipo_vidrio` VALUES (NULL, 'Temp 8', 15000);
INSERT INTO `tipo_vidrio` VALUES (NULL, 'Temp 10', 14000);

CREATE TABLE `cotizaciones` (
  `id` int(11) AUTO_INCREMENT PRIMARY KEY,
  `region_id` int(11),
  `tipo_vidrio_id` int(11),
  `descuento` int(11) not null default '0',
  FOREIGN KEY (`region_id`) REFERENCES `regiones`(`id`),
  FOREIGN KEY (`tipo_vidrio_id`) REFERENCES `tipo_vidrio`(`id`)
);

CREATE TABLE `vanos` (
  `id` int(11) AUTO_INCREMENT PRIMARY KEY,
  `cantidad_aperturas` int(11),
  `ancho` decimal(6,2),
  `alto` decimal(6,2),
  `cotizacion_id` int(11),
  FOREIGN KEY (`cotizacion_id`) REFERENCES `cotizaciones`(`id`)
);

CREATE TABLE `complementarios` (
  `id` int(11) AUTO_INCREMENT PRIMARY KEY,
  `monto` int(11) not null default '0',
  `detalle` varchar(50),
  `cotizacion_id` int(11),
  FOREIGN KEY (`cotizacion_id`) REFERENCES `cotizaciones`(`id`)
);

CREATE TABLE `tipo_costo` (
  `id` int(11) AUTO_INCREMENT PRIMARY KEY,
  `nombre` varchar(45),
  `es_sueldo` tinyint(1)
);
INSERT INTO `tipo_costo` VALUES (NULL, 'Metro lineal sistema', 0);
INSERT INTO `tipo_costo` VALUES (NULL, 'Area vano', 0);
INSERT INTO `tipo_costo` VALUES (NULL, 'Aperturas', 0);
INSERT INTO `tipo_costo` VALUES (NULL, 'Cantidad de aperturas', 0);
INSERT INTO `tipo_costo` VALUES (NULL, 'Paneles', 0);
INSERT INTO `tipo_costo` VALUES (NULL, 'Otro', 0);
INSERT INTO `tipo_costo` VALUES (NULL, 'Instaladores fijo + cotizaciones + bonos meta', 1);
INSERT INTO `tipo_costo` VALUES (NULL, 'Instaladores variables', 1);
INSERT INTO `tipo_costo` VALUES (NULL, 'Reparaciones y/u otro', 1);
INSERT INTO `tipo_costo` VALUES (NULL, 'Producción fijo + cotizaciones', 1);
INSERT INTO `tipo_costo` VALUES (NULL, 'Producción variables', 1);
INSERT INTO `tipo_costo` VALUES (NULL, 'Medición (viaje+sueldo+variable)', 1);

CREATE TABLE `costos` (
  `id` int(11) AUTO_INCREMENT PRIMARY KEY,
  `valor_inicial` int(11),
  `costo_final` int(11),
  `tipo_costo_id` int(11),
  `cotizacion_id` int(11),
  FOREIGN KEY (`tipo_costo_id`) REFERENCES `tipo_costo`(`id`),
  FOREIGN KEY (`cotizacion_id`) REFERENCES `cotizaciones`(`id`)
);

garantia nav entre producto y region, medio de pago