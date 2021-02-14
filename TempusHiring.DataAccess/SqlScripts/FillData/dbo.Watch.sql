INSERT INTO Watches (Diameter, Description, Price, Gender, CountInStock, SaledCount, ManufacturerId, GlassMaterialId, MechanismId, BodyMaterialId, StrapId, Title) 
             VALUES (50, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Woman', 12, 0, 9, 2, 1, 1, 1, ''),
                    (46, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Woman', 12, 0, 9, 1, 2, 2, 2, ''),
                    (38, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Unisex', 12, 0, 9, 3, 3, 3, 3, ''),
                    (29.6, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Man', 12, 0, 8, 2, 4, 4, 4, ''),
                    (38, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Unisex', 12, 0, 7, 1, 5, 5, 5, ''),
                    (50, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Woman', 12, 0, 6, 3, 6, 6, 6, ''),
                    (38, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Man', 12, 0, 5, 2, 1, 7, 1, ''),
                    (29.6, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Man', 12, 0, 4, 1, 2, 8, 2, ''),
                    (38, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Unisex', 12, 0, 3, 3, 3, 9, 3, ''),
                    (46, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Woman', 12, 0, 2, 2, 4, 1, 4, ''),
                    (50, 'Some default description', ROUND(RAND(1) * 100000, 0), 'Man', 12, 0, 1, 1, 5, 2, 5, '');