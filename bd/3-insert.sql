-- Ingresar cargos
INSERT INTO `prueba`.`cargos`
(`codigo`, `nombre`, `activo`, `idUsuarioCreacion`)
VALUES
('ADM', 'Administrador', TRUE, 1),
('LFE', 'Líder Frontend', TRUE, 1),
('LBE', 'Líder Backend', TRUE, 1),
('DFE', 'Desarrollador Frontend', TRUE, 1),
('ABG', 'Abogado', TRUE, 1),
('GSS', 'Guardia', TRUE, 1),
('PRO', 'Proveedor', TRUE, 1);

-- Ingresar departamentos
INSERT INTO `prueba`.`departamentos`
(`codigo`, `nombre`, `activo`, `idUsuarioCreacion`)
VALUES
('TI', 'Tecnologías de la Información', TRUE, 1),
('LE', 'Legal', TRUE, 1),
('SE', 'Seguridad', TRUE, 1),
('EB', 'Eventos y Buffets', TRUE, 1);

