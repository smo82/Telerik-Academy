-- SupermarketOAccessModel.Measure
CREATE TABLE `measures` (
    `MeasureName` nvarchar(45) NOT NULL,    -- _measureName
    `MeasureId` integer AUTO_INCREMENT NOT NULL, -- _measureId
    CONSTRAINT `pk_measures` PRIMARY KEY (`MeasureId`)
) ENGINE = InnoDB;

-- SupermarketOAccessModel.Product
CREATE TABLE `products` (
    `VendorId` integer NOT NULL,            -- _vendor
    `ProductPrice` decimal(10,2) NOT NULL,  -- _productPrice
    `ProductName` nvarchar(45) NOT NULL,    -- _productName
    `ProductId` integer AUTO_INCREMENT NOT NULL, -- _productId
    `MeasureId` integer NOT NULL,           -- _measure
    CONSTRAINT `pk_products` PRIMARY KEY (`ProductId`)
) ENGINE = InnoDB;

-- SupermarketOAccessModel.Vendor
CREATE TABLE `vendors` (
    `VendorName` nvarchar(45) NOT NULL,     -- _vendorName
    `VendorId` integer AUTO_INCREMENT NOT NULL, -- _vendorId
    CONSTRAINT `pk_vendors` PRIMARY KEY (`VendorId`)
) ENGINE = InnoDB;

ALTER TABLE `measures` ADD UNIQUE `MeasursId_UNIQUE`(`MeasureId`);

ALTER TABLE `products` ADD UNIQUE `ProductId_UNIQUE`(`ProductId`);

ALTER TABLE `products` ADD INDEX `fk_Products_Vendors_idx`(`VendorId`);

ALTER TABLE `products` ADD INDEX `fk_Products_Measurs1_idx`(`MeasureId`);

ALTER TABLE `vendors` ADD UNIQUE `VendorId_UNIQUE`(`VendorId`);

ALTER TABLE `products` ADD CONSTRAINT `fk_Products_Measurs1` FOREIGN KEY `fk_Products_Measurs1` (`MeasureId`) REFERENCES `measures` (`MeasureId`);

ALTER TABLE `products` ADD CONSTRAINT `fk_Products_Vendors` FOREIGN KEY `fk_Products_Vendors` (`VendorId`) REFERENCES `vendors` (`VendorId`);

