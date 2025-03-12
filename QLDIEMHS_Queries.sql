CREATE DATABASE QuanLyDiemTHCS;
GO

USE QuanLyDiemTHCS;
GO

-- Tạo bảng tblLophoc
CREATE TABLE tblLophoc (
    MaLop varchar(10) PRIMARY KEY,
    TenLop nvarchar(50) NOT NULL,
    NamHoc nvarchar(9) NOT NULL,
    Khoi varchar(2) NOT NULL CHECK (Khoi IN ('6A', '6B', '6C', '6D', '7A', '7B', '7C', '7D', 
                                            '8A', '8B', '8C', '8D', '9A', '9B', '9C', '9D'))
);

-- Tạo bảng tblHocsinh (không có MaLop)
CREATE TABLE tblHocsinh (
    MaHS varchar(10) PRIMARY KEY,
    HoTen nvarchar(50) NOT NULL,
    NgaySinh date,
    GioiTinh bit,
	MaLop varchar(10),
	FOREIGN KEY (MaLop) REFERENCES tblLophoc(MaLop)
);

-- Tạo bảng tblNhommonhoc

CREATE TABLE tblNhommonhoc (
    MaNhom varchar(10) PRIMARY KEY,
    TenNhom nvarchar(50) NOT NULL
);

-- Tạo bảng tblMonhoc
CREATE TABLE tblMonhoc (
    MaMH varchar(10) PRIMARY KEY,
    TenMH nvarchar(50) NOT NULL,
    Khoi int NOT NULL CHECK (Khoi IN (6, 7, 8, 9)),
    MaNhom varchar(10),
    FOREIGN KEY (MaNhom) REFERENCES tblNhommonhoc(MaNhom)
);

-- Tạo bảng tblLoaidiem
CREATE TABLE tblLoaidiem (
    MaLoaiDiem varchar(10) PRIMARY KEY,
    TenLoaiDiem nvarchar(50) NOT NULL,
    HeSo int NOT NULL CHECK (HeSo IN (1, 2, 3))
);

-- Tạo bảng tblDiem
CREATE TABLE tblDiem (
    MaDiem varchar(10) PRIMARY KEY,
    MaHS varchar(10) NOT NULL,
    MaLop varchar(10) NOT NULL,
    MaMH varchar(10) NOT NULL,
    MaLoaiDiem varchar(10) NOT NULL,
    Diem float CHECK (Diem >= 0 AND Diem <= 10),
    HocKy int CHECK (HocKy IN (1, 2)),
    NamHoc nvarchar(9) NOT NULL,
    FOREIGN KEY (MaHS) REFERENCES tblHocsinh(MaHS),
    FOREIGN KEY (MaLop) REFERENCES tblLophoc(MaLop),
    FOREIGN KEY (MaMH) REFERENCES tblMonhoc(MaMH),
    FOREIGN KEY (MaLoaiDiem) REFERENCES tblLoaidiem(MaLoaiDiem)
);
	
-- Tạo bảng tblHanhKiem
CREATE TABLE tblHanhKiem (
    MaHK varchar(10) PRIMARY KEY,
    MaHS varchar(10) NOT NULL,
    MaLop varchar(10) NOT NULL,
    HocKy int CHECK (HocKy IN (1, 2)),
    NamHoc nvarchar(9) NOT NULL,
	DiemTrungBinh FLOAT,
	HocLuc nvarchar(20) NOT NULL CHECK (HocLuc IN (N'Giỏi', N'Khá', N'Trung bình', N'Yếu', N'Kém')),
    HanhKiem nvarchar(20) NOT NULL CHECK (HanhKiem IN (N'Tốt', N'Khá', N'Trung bình', N'Yếu')),
    FOREIGN KEY (MaHS) REFERENCES tblHocsinh(MaHS),
    FOREIGN KEY (MaLop) REFERENCES tblLophoc(MaLop)
);

CREATE TABLE tblGiaovien (
    MaGV varchar(10) PRIMARY KEY,
    HoTen nvarchar(50) NOT NULL,
    NgaySinh date,
    GioiTinh bit,
    Username nvarchar(50) UNIQUE NOT NULL,
    PasswordHash nvarchar(255) NOT NULL, -- Lưu mật khẩu đã mã hóa
    Email nvarchar(100) UNIQUE,
    SoDienThoai nvarchar(15)
);

ALTER TABLE tblLophoc
ALTER COLUMN NamHoc DATE;

ALTER TABLE tblDiem
ALTER COLUMN NamHoc nvarchar(10) NULL;

ALTER TABLE tblHanhkiem
ALTER COLUMN NamHoc nvarchar(10) NULL;

-- STORE_PROCEDURE CHO GIAO VIEN
CREATE PROCEDURE sp_GiaoVien_CRUD
    @Action VARCHAR(10),
    @MaGV VARCHAR(10) = NULL,
    @HoTen NVARCHAR(100) = NULL,
    @NgaySinh DATE = NULL,
    @GioiTinh BIT = NULL,
    @Username NVARCHAR(50) = NULL,
    @PasswordHash NVARCHAR(255) = NULL,
	@Email NVARCHAR(100) = NULL,
    @SoDienThoai VARCHAR(15) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN

        -- Kiểm tra MaGV có tồn tại không
        IF @MaGV IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblGiaovien WHERE MaGV = @MaGV)
        BEGIN
            RAISERROR ('MaGV không tồn tại trong tblGiaovien.', 16, 1);
            RETURN;
        END

		DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Lấy số lớn nhất từ các mã hiện có dạng HHxxx và tăng lên 1
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaGV, 3, 3) AS INT)), 0) + 1
        FROM tblGiaovien
        WHERE MaGV LIKE 'GV[0-9][0-9][0-9]';

        -- Nếu bảng rỗng, bắt đầu từ 1
        IF @NextID IS NULL SET @NextID = 1;

        -- Tạo mã mới (HHxxx)
        SET @NewCode = 'GV' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

		-- Mã hóa mật khẩu
        DECLARE @HashedPassword VARBINARY(64);
        SET @HashedPassword = HASHBYTES('SHA2_256', @PasswordHash);

        -- Kiểm tra nếu mã vượt quá HH999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (GV999).', 16, 1);
            RETURN;
        END;

        INSERT INTO tblGiaovien(MaGV, HoTen, NgaySinh, GioiTinh, Username, PasswordHash, Email, SoDienThoai)
        VALUES (@NewCode, @HoTen, @NgaySinh, @GioiTinh, @Username, @HashedPassword, @Email, @SoDienThoai);

        SELECT @NewCode AS MaGV;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @MaGV IS NULL
            SELECT 
				MaGV, 
				HoTen, 
				NgaySinh,
				GioiTinh, 
				Username, 
				PasswordHash,
				Email, 
				SoDienThoai
			FROM tblGiaovien
		 ELSE 
            SELECT 
				MaGV, 
				HoTen, 
				NgaySinh,
				GioiTinh, 
				Username, 
				PasswordHash,
				Email, 
				SoDienThoai
			FROM tblGiaovien
			WHERE MaGV = @MaGV;
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE tblGiaovien
        SET HoTen = @HoTen,
            NgaySinh = @NgaySinh,
            GioiTinh = @GioiTinh,
			Username = COALESCE(@Username, Username),
			PasswordHash = COALESCE(@PasswordHash, PasswordHash),
            Email = @Email,
            SoDienThoai = @SoDienThoai
        WHERE MaGV = @MaGV;
        SELECT @@ROWCOUNT AS RowsAffected;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblGiaovien WHERE MaGV = @MaGV;
        SELECT @@ROWCOUNT AS RowsAffected;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO

-- STORE_PROCEDURE CHO LOP HOC
CREATE PROCEDURE sp_Lophoc_CRUD
    @Action VARCHAR(10),
    @MaLop VARCHAR(10) = NULL,
    @TenLop NVARCHAR(50) = NULL,
    @NamHoc NVARCHAR(9) = NULL,
    @Khoi VARCHAR(3) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
		DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(6);

         -- Kiểm tra MaGV có tồn tại không
        IF @MaLop IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblLophoc WHERE MaLop = @MaLop)
        BEGIN
            RAISERROR ('MaLop không tồn tại trong tblLophoc.', 16, 1);
            RETURN;
        END

		SET @NextID = 1;
        WHILE EXISTS (SELECT 1 FROM tblLophoc WHERE MaLop = 'ML' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3))
        BEGIN
            SET @NextID = @NextID + 1;
        END;
        SET @NewCode = 'ML' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

		-- Kiểm tra định dạng Khoi
        IF @Khoi NOT IN ('6A', '6B', '6C', '6D', '7A', '7B', '7C', '7D', 
                        '8A', '8B', '8C', '8D', '9A', '9B', '9C', '9D')
        BEGIN
            RAISERROR ('Khoi không hợp lệ. Chỉ chấp nhận 6A-6D, 7A-7D, 8A-8D, 9A-9D.', 16, 1);
            RETURN;
        END

        INSERT INTO tblLophoc(MaLop, TenLop, NamHoc, Khoi)
        VALUES (@NewCode, @TenLop, @NamHoc, @Khoi);

        SELECT @NewCode AS MaLop;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @MaLop IS NULL
            SELECT DISTINCT MaLop, TenLop, NamHoc, Khoi
            FROM tblLophoc
        ELSE 
            SELECT DISTINCT MaLop, TenLop, NamHoc, Khoi
            FROM tblLophoc
            WHERE MaLop = @MaLop;
    END

	ELSE IF @Action = 'SELECT_D'
	BEGIN
		IF @MaLop IS NULL
			SELECT DISTINCT TenLop
			FROM tblLophoc;
		ELSE
			SELECT DISTINCT TenLop
			FROM tblLophoc
			WHERE MaLop = @MaLop;
	END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE tblLophoc
        SET TenLop = @TenLop,
            NamHoc = @NamHoc,
            Khoi = @Khoi
        WHERE MaLop = @MaLop;
        SELECT @@ROWCOUNT AS RowsAffected;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblLophoc WHERE MaLop = @MaLop;
        SELECT @@ROWCOUNT AS RowsAffected;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END
GO

-- STORE_PROCEDURE CHO HOC SINH
CREATE PROCEDURE sp_Hocsinh_CRUD
    @Action VARCHAR(10),
    @MaHS VARCHAR(10) = NULL,
    @HoTen NVARCHAR(50) = NULL,
    @NgaySinh DATE = NULL,
    @GioiTinh BIT = NULL,
    @MaLop VARCHAR(10) = NULL,
	@Khoi VARCHAR(10) = NULL,
	@TenLop NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
        -- Kiểm tra MaHS có tồn tại không
        IF EXISTS (SELECT 1 FROM tblHocsinh WHERE MaHS = @MaHS)
        BEGIN
            RAISERROR ('MaHS đã tồn tại trong tblHocsinh.', 16, 1);
            RETURN;
        END

        -- Kiểm tra MaLop có tồn tại trong tblLophoc không
        IF @MaLop IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblLophoc WHERE MaLop = @MaLop)
        BEGIN
            RAISERROR ('MaLop không tồn tại trong tblLophoc.', 16, 1);
            RETURN;
        END

        DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Tạo mã HSxxx tự động
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaHS, 3, 3) AS INT)), 0) + 1
        FROM tblHocsinh
        WHERE MaHS LIKE 'HS[0-9][0-9][0-9]';

        IF @NextID IS NULL SET @NextID = 1;

        SET @NewCode = 'HS' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

        -- Kiểm tra nếu mã vượt quá HS999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (HS999).', 16, 1);
            RETURN;
        END;

        INSERT INTO tblHocsinh(MaHS, HoTen, NgaySinh, GioiTinh, MaLop)
        VALUES (@NewCode, @HoTen, @NgaySinh, @GioiTinh, @MaLop);

        SELECT @NewCode AS MaHS;
    END

    IF @Action = 'SELECT'
    BEGIN
        IF @MaHS IS NULL AND @Khoi IS NULL AND @TenLop IS NULL
            SELECT h.MaHS, h.HoTen, h.NgaySinh, h.GioiTinh, h.MaLop, lh.TenLop
            FROM tblHocsinh h
            LEFT JOIN tblLophoc lh ON h.MaLop = lh.MaLop
        ELSE IF @Khoi IS NOT NULL AND @TenLop IS NULL -- Chỉ lọc theo khối
            SELECT h.MaHS, h.HoTen, h.NgaySinh, h.GioiTinh, h.MaLop, lh.TenLop
            FROM tblHocsinh h
            LEFT JOIN tblLophoc lh ON h.MaLop = lh.MaLop
            WHERE lh.Khoi = @Khoi;
        ELSE
            SELECT h.MaHS, h.HoTen, h.NgaySinh, h.GioiTinh, h.MaLop, lh.TenLop
            FROM tblHocsinh h
            LEFT JOIN tblLophoc lh ON h.MaLop = lh.MaLop
            WHERE
                (@MaHS IS NULL OR h.MaHS = @MaHS) AND
                (@Khoi IS NULL OR lh.Khoi = @Khoi) AND
                (@TenLop IS NULL OR lh.TenLop = @TenLop); -- Lọc theo tên lớp
    END


    ELSE IF @Action = 'UPDATE'
    BEGIN
        -- Kiểm tra MaLop có tồn tại trong tblLophoc không
        IF @MaLop IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblLophoc WHERE MaLop = @MaLop)
        BEGIN
            RAISERROR ('MaLop không tồn tại trong tblLophoc.', 16, 1);
            RETURN;
        END

        UPDATE tblHocsinh
        SET HoTen = @HoTen,
            NgaySinh = @NgaySinh,
            GioiTinh = @GioiTinh,
            MaLop = @MaLop
        WHERE MaHS = @MaHS;
        SELECT @@ROWCOUNT AS RowsAffected;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblHocsinh WHERE MaHS = @MaHS;
        SELECT @@ROWCOUNT AS RowsAffected;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO

CREATE PROCEDURE sp_Nhommonhoc_CRUD
    @Action VARCHAR(10),
    @MaNhom VARCHAR(10) = NULL,
    @TenNhom NVARCHAR(50) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
        DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Lấy số lớn nhất từ các mã hiện có dạng NMxxx và tăng lên 1
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaNhom, 3, 3) AS INT)), 0) + 1
        FROM tblNhommonhoc
        WHERE MaNhom LIKE 'NM[0-9][0-9][0-9]';

        -- Nếu bảng rỗng, bắt đầu từ 1
        IF @NextID IS NULL SET @NextID = 1;

        -- Tạo mã mới (NMxxx)
        SET @NewCode = 'NM' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

        -- Kiểm tra nếu mã vượt quá NM999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (NM999).', 16, 1);
            RETURN;
        END;

        INSERT INTO tblNhommonhoc(MaNhom, TenNhom)
        VALUES (@NewCode, @TenNhom);

        SELECT @NewCode AS MaNhom;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @MaNhom IS NULL
            SELECT MaNhom, TenNhom
            FROM tblNhommonhoc
        ELSE 
            SELECT MaNhom, TenNhom
            FROM tblNhommonhoc
            WHERE MaNhom = @MaNhom;
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE tblNhommonhoc
        SET TenNhom = @TenNhom
        WHERE MaNhom = @MaNhom;
        SELECT @@ROWCOUNT AS RowsAffected;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblNhommonhoc 
        WHERE MaNhom = @MaNhom;
        SELECT @@ROWCOUNT AS RowsAffected;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO

CREATE PROCEDURE sp_Monhoc_CRUD
    @Action VARCHAR(10),
    @MaMH VARCHAR(10) = NULL,
    @TenMH NVARCHAR(50) = NULL,
    @Khoi INT = NULL,
    @MaNhom VARCHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
        DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Lấy số lớn nhất từ các mã hiện có dạng MHxxx và tăng lên 1
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaMH, 3, 3) AS INT)), 0) + 1
        FROM tblMonhoc
        WHERE MaMH LIKE 'MH[0-9][0-9][0-9]';

        -- Nếu bảng rỗng, bắt đầu từ 1
        IF @NextID IS NULL SET @NextID = 1;

        -- Tạo mã mới (MHxxx)
        SET @NewCode = 'MH' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

        -- Kiểm tra nếu mã vượt quá MH999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (MH999).', 16, 1);
            RETURN;
        END;

        -- Kiểm tra MaNhom có tồn tại trong tblNhommonhoc không
        IF @MaNhom IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblNhommonhoc WHERE MaNhom = @MaNhom)
        BEGIN
            RAISERROR ('MaNhom không tồn tại trong tblNhommonhoc.', 16, 1);
            RETURN;
        END

        -- Kiểm tra Khoi hợp lệ
        IF @Khoi NOT IN (6, 7, 8, 9)
        BEGIN
            RAISERROR ('Khoi phải là 6, 7, 8 hoặc 9.', 16, 1);
            RETURN;
        END

        INSERT INTO tblMonhoc(MaMH, TenMH, Khoi, MaNhom)
        VALUES (@NewCode, @TenMH, @Khoi, @MaNhom);

        SELECT @NewCode AS MaMH;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @MaMH IS NULL
            SELECT h.MaMH, h.TenMH, h.Khoi, h.MaNhom, mh.TenNhom
            FROM tblMonhoc h
			LEFT JOIN tblNhommonhoc mh ON h.MaNhom = mh.MaNhom
        ELSE 
            SELECT h.MaMH, h.TenMH, h.Khoi, h.MaNhom, mh.TenNhom
            FROM tblMonhoc h
			LEFT JOIN tblNhommonhoc mh ON h.MaNhom = mh.MaNhom
            WHERE h.MaMH = @MaMH;
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        -- Kiểm tra MaNhom có tồn tại trong tblNhommonhoc không
        IF @MaNhom IS NOT NULL AND NOT EXISTS (SELECT 1 FROM tblNhommonhoc WHERE MaNhom = @MaNhom)
        BEGIN
            RAISERROR ('MaNhom không tồn tại trong tblNhommonhoc.', 16, 1);
            RETURN;
        END

        -- Kiểm tra Khoi hợp lệ
        IF @Khoi IS NOT NULL AND @Khoi NOT IN (6, 7, 8, 9)
        BEGIN
            RAISERROR ('Khoi phải là 6, 7, 8 hoặc 9.', 16, 1);
            RETURN;
        END

        UPDATE tblMonhoc
        SET TenMH = @TenMH,
            Khoi = @Khoi,
            MaNhom = @MaNhom
        WHERE MaMH = @MaMH;
        SELECT @@ROWCOUNT AS RowsAffected;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblMonhoc 
        WHERE MaMH = @MaMH;
        SELECT @@ROWCOUNT AS RowsAffected;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO

-- Stored Procedure cho bảng tblLoaidiem
CREATE PROCEDURE sp_Loaidiem_CRUD
    @Action VARCHAR(10),
    @MaLoaiDiem VARCHAR(10) = NULL,
    @TenLoaiDiem NVARCHAR(50) = NULL,
    @HeSo INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
		DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Lấy số lớn nhất từ các mã hiện có dạng MHxxx và tăng lên 1
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaLoaiDiem, 3, 3) AS INT)), 0) + 1
        FROM tblLoaidiem
        WHERE MaLoaiDiem LIKE 'LD[0-9][0-9][0-9]';

        -- Nếu bảng rỗng, bắt đầu từ 1
        IF @NextID IS NULL SET @NextID = 1;

        -- Tạo mã mới (MHxxx)
        SET @NewCode = 'LD' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

        -- Kiểm tra nếu mã vượt quá MH999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (LD999).', 16, 1);
            RETURN;
        END;

        INSERT INTO tblLoaidiem (MaLoaiDiem, TenLoaiDiem, HeSo)
        VALUES (@NewCode, @TenLoaiDiem, @HeSo);

		SELECT @NewCode AS MaLoaiDiem;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @MaLoaiDiem IS NULL
            SELECT * FROM tblLoaidiem;
        ELSE 
            SELECT * FROM tblLoaidiem WHERE MaLoaiDiem = @MaLoaiDiem;
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
		-- Kiểm tra Khoi hợp lệ
        IF @HeSo IS NOT NULL AND @HeSo NOT IN (1, 2, 3)
        BEGIN
            RAISERROR ('Hệ số phải là 1, 2, 3', 16, 1);
            RETURN;
        END

        UPDATE tblLoaidiem
        SET TenLoaiDiem = @TenLoaiDiem, HeSo = @HeSo
        WHERE MaLoaiDiem = @MaLoaiDiem;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblLoaidiem WHERE MaLoaiDiem = @MaLoaiDiem;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO

-- Stored Procedure cho bảng tblDiem
CREATE PROCEDURE sp_Diem_CRUD
    @Action VARCHAR(10),
    @MaDiem VARCHAR(10) = NULL,
    @MaHS VARCHAR(10) = NULL,
    @MaLop VARCHAR(10) = NULL,
    @MaMH VARCHAR(10) = NULL,
    @MaLoaiDiem VARCHAR(10) = NULL,
    @Diem FLOAT = NULL,
    @HocKy INT = NULL,
    @NamHoc NVARCHAR(9) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
	BEGIN
		DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Lấy số lớn nhất từ các mã hiện có dạng MHxxx và tăng lên 1
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaDiem, 3, 3) AS INT)), 0) + 1
        FROM tblDiem
        WHERE MaDiem LIKE 'DS[0-9][0-9][0-9]';

        -- Nếu bảng rỗng, bắt đầu từ 1
        IF @NextID IS NULL SET @NextID = 1;

        -- Tạo mã mới (MHxxx)
        SET @NewCode = 'DS' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

        -- Kiểm tra nếu mã vượt quá MH999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (DS999).', 16, 1);
            RETURN;
        END;

       -- Kiểm tra trùng lặp MaLoaiDiem cho MaMH
        IF EXISTS (SELECT 1 FROM tblDiem WHERE MaHS = @MaHS AND MaMH = @MaMH AND MaLoaiDiem = @MaLoaiDiem)
         BEGIN
             RAISERROR ('Loại điểm này đã được thêm cho môn học.', 16, 1);
             RETURN;
         END;

        INSERT INTO tblDiem (MaDiem, MaHS, MaLop, MaMH, MaLoaiDiem, Diem, HocKy, NamHoc)
        VALUES (@NewCode, @MaHS, @MaLop, @MaMH, @MaLoaiDiem, @Diem, @HocKy, @NamHoc);

		SELECT @NewCode AS MaLoaiDiem;
    END

    ELSE IF @Action = 'SELECT'
    BEGIN
        IF @MaDiem IS NULL AND @MaHS IS NULL
            SELECT 
				h.MaDiem,
				h.MaHS,
				hs.HoTen,
				h.MaLop,
				lh.TenLop,
				h.MaMH,
				mh.TenMH,
				h.MaLoaiDiem,
				ld.TenLoaiDiem,
				ld.HeSo,
				h.Diem,
				h.HocKy,
				h.NamHoc,
				hk.MaHK,
				hk.HanhKiem
			FROM tblDiem h
			LEFT JOIN tblHocsinh hs ON h.MaHS = hs.MaHS
			LEFT JOIN tblLophoc lh ON h.MaLop = lh.MaLop
			LEFT JOIN tblMonhoc mh ON h.MaMH = mh.MaMH
			LEFT JOIN tblLoaidiem ld ON h.MaLoaiDiem = ld.MaLoaiDiem
			RIGHT JOIN tblHanhKiem hk
				ON h.MaHS = hk.MaHS
				AND h.MaLop = hk.MaLop
        ELSE 
            SELECT 
				h.MaDiem,
				h.MaHS,
				hs.HoTen,
				h.MaLop,
				lh.TenLop,
				h.MaMH,
				mh.TenMH,
				h.MaLoaiDiem,
				ld.TenLoaiDiem,
				ld.HeSo,
				h.Diem,
				h.HocKy,
				h.NamHoc,
				hk.MaHK,
				hk.HanhKiem
			FROM tblDiem h 
				LEFT JOIN tblHocsinh hs ON h.MaHS = hs.MaHS
				LEFT JOIN tblLophoc lh ON h.MaLop = lh.MaLop
				LEFT JOIN tblMonhoc mh ON h.MaMH = mh.MaMH
				LEFT JOIN tblLoaidiem ld ON h.MaLoaiDiem = ld.MaLoaiDiem
				LEFT JOIN tblHanhKiem hk
					ON h.MaHS = hk.MaHS
					AND h.MaLop = hk.MaLop
			WHERE h.MaHS = @MaHS;
    END

	ELSE IF @Action = 'UPDATE'
	BEGIN
		-- Lấy thông tin loại điểm cũ
		DECLARE @OldMaLoaiDiem VARCHAR(10);
		SELECT @OldMaLoaiDiem = MaLoaiDiem FROM tblDiem WHERE MaDiem = @MaDiem;

		-- Kiểm tra nếu loại điểm mới khác loại điểm cũ
		IF @MaLoaiDiem <> @OldMaLoaiDiem
		BEGIN
			-- Kiểm tra trùng lặp MaLoaiDiem cho MaMH
			IF EXISTS (SELECT 1 FROM tblDiem WHERE MaHS = @MaHS AND MaMH = @MaMH AND MaLoaiDiem = @MaLoaiDiem AND MaDiem <> @MaDiem)
			BEGIN
				RAISERROR ('Loại điểm này đã được thêm cho môn học.', 16, 1);
				RETURN;
			END;
		END;

		UPDATE tblDiem
		SET MaHS = @MaHS, MaLop = @MaLop, MaMH = @MaMH, MaLoaiDiem = @MaLoaiDiem,
			Diem = @Diem, HocKy = @HocKy, NamHoc = @NamHoc
		WHERE MaDiem = @MaDiem;

		-- Trả về 1 nếu có dòng bị ảnh hưởng, 0 nếu không có dòng nào được cập nhật
		IF @@ROWCOUNT > 0
			SELECT 1 AS AffectedRows;
		ELSE
			SELECT 0 AS AffectedRows;
	END;

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblDiem WHERE MaDiem = @MaDiem;

				-- Trả về 1 nếu có dòng bị ảnh hưởng, 0 nếu không có dòng nào được cập nhật
		IF @@ROWCOUNT > 0
			SELECT 1 AS AffectedRows;
		ELSE
			SELECT 0 AS AffectedRows;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO

-- Stored Procedure cho bảng tblHanhKiem
CREATE PROCEDURE sp_HanhKiem_CRUD
    @Action VARCHAR(10),
    @MaHK VARCHAR(10) = NULL,
    @MaHS VARCHAR(10) = NULL,
    @MaLop VARCHAR(10) = NULL,
    @HocKy INT = NULL,
    @NamHoc NVARCHAR(9) = NULL,
    @DiemTrungBinh FLOAT = NULL,
	@HocLuc NVARCHAR(20) = NULL,
    @HanhKiem NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN

		DECLARE @NextID INT;
        DECLARE @NewCode VARCHAR(10);

        -- Lấy số lớn nhất từ các mã hiện có dạng MHxxx và tăng lên 1
        SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(MaHK, 3, 3) AS INT)), 0) + 1
        FROM tblHanhKiem
        WHERE MaHK LIKE 'HK[0-9][0-9][0-9]';

        -- Nếu bảng rỗng, bắt đầu từ 1
        IF @NextID IS NULL SET @NextID = 1;

        -- Tạo mã mới (MHxxx)
        SET @NewCode = 'HK' + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3);

        -- Kiểm tra nếu mã vượt quá MH999
        IF @NextID > 999
        BEGIN
            RAISERROR ('Đã vượt quá số lượng mã tối đa (HK999).', 16, 1);
            RETURN;
        END;

		       -- Kiểm tra trùng lặp MaLoaiDiem cho MaMH
        IF EXISTS (SELECT 1 FROM tblHanhKiem WHERE MaHS = @MaHS)
         BEGIN
             RAISERROR ('Học sinh này đã có hạnh kiểm, muốn thay đổi hãy sửa lại', 16, 1);
             RETURN;
         END;

        INSERT INTO tblHanhKiem (MaHK, MaHS, MaLop, HocKy, NamHoc, DiemTrungBinh, HocLuc, HanhKiem)
        VALUES (@NewCode, @MaHS, @MaLop, @HocKy, @NamHoc, @DiemTrungBinh, @HocLuc, @HanhKiem);

		SELECT @NewCode AS MaHK;
    END

	ELSE IF @Action = 'SELECT'
	BEGIN
		IF @MaHK IS NULL AND @MaHS IS NULL
			SELECT * FROM tblHanhKiem;
		ELSE IF @MaHK IS NOT NULL AND @MaHS IS NULL
			SELECT * FROM tblHanhKiem WHERE MaHK = @MaHK;
		ELSE IF @MaHK IS NULL AND @MaHS IS NOT NULL
			SELECT * FROM tblHanhKiem WHERE MaHS = @MaHS;
		ELSE 
			SELECT * FROM tblHanhKiem WHERE MaHK = @MaHK AND MaHS = @MaHS;
	END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE tblHanhKiem
        SET MaHS = @MaHS, MaLop = @MaLop, HocKy = @HocKy, NamHoc = @NamHoc, 
            DiemTrungBinh = @DiemTrungBinh, HocLuc = @HocLuc, HanhKiem = @HanhKiem
        WHERE MaHK = @MaHK;

				-- Trả về 1 nếu có dòng bị ảnh hưởng, 0 nếu không có dòng nào được cập nhật
		IF @@ROWCOUNT > 0
			SELECT 1 AS AffectedRows;
		ELSE
			SELECT 0 AS AffectedRows;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM tblHanhKiem WHERE MaHK = @MaHK;
    END
    ELSE
    BEGIN
        RAISERROR ('Invalid Action. Use INSERT, SELECT, UPDATE, or DELETE.', 16, 1);
    END
END;
GO


CREATE PROCEDURE sp_DangNhap
    @Username nvarchar(50),
    @Password nvarchar(255),
    @Result int OUTPUT,
    @Message nvarchar(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Khai báo biến để lưu thông tin
    DECLARE @HashedPassword VARBINARY(64);
    SET @HashedPassword = HASHBYTES('SHA2_256', @Password);

    BEGIN TRY
        -- Kiểm tra username
        IF EXISTS (SELECT 1 FROM tblGiaovien WHERE Username = @Username)
        BEGIN
            IF EXISTS (SELECT 1 FROM tblGiaovien WHERE Username = @Username AND PasswordHash = @HashedPassword)
            BEGIN
                SET @Result = 1;
                SET @Message = N'Đăng nhập thành công';

            END
            ELSE
            BEGIN
                SET @Result = 0;
                SET @Message = N'Mật khẩu không đúng';
            END
        END
        ELSE
        BEGIN
            SET @Result = 0;
            SET @Message = N'Tài khoản không tồn tại';
        END
    END TRY
    BEGIN CATCH
        SET @Result = -1;
        SET @Message = N'Lỗi hệ thống: ' + ERROR_MESSAGE();
    END CATCH
END;
GO


EXEC sp_GiaoVien_CRUD 'INSERT', NULL, N'Nguyễn Thị Duyên', '1990-01-01', 0 , 'user2', N'123456', 'nguyenthiduyen1@gmail.com', '0955568003';
-- Giáo viên 1
EXEC sp_GiaoVien_CRUD 'INSERT', NULL, N'Trần Văn An', '1985-05-15', 1, 'an.tran', N'matkhau123', 'tranvanan@gmail.com', '0912345678';

-- Giáo viên 2
EXEC sp_GiaoVien_CRUD 'INSERT', NULL, N'Lê Thị Bình', '1992-09-20', 0, 'binh.le', N'password456', 'lethibinh@yahoo.com', '0987654321';

-- Giáo viên 3
EXEC sp_GiaoVien_CRUD 'INSERT', NULL, N'Phạm Hoàng Cường', '1988-03-10', 1, 'cuong.pham', N'secure789', 'phamhoangcuong@outlook.com', '0901234567';

-- Giáo viên 4
EXEC sp_GiaoVien_CRUD 'INSERT', NULL, N'Hoàng Thu Dung', '1995-12-01', 0, 'dung.hoang', N'pass1234', 'hoangthudung@gmail.com', '0978901234';

-- Giáo viên 5
EXEC sp_GiaoVien_CRUD 'INSERT', NULL, N'Vũ Đức Em', '1987-07-25', 1, 'em.vu', N'password5678', 'vuducem@yahoo.com', '0934567890';

EXEC sp_GiaoVien_CRUD 'SELECT';
EXEC sp_GiaoVien_CRUD @Action = 'UPDATE',
					  @MaGV = 'GV001',
					  @HoTen = N'Nguyễn Thị Xuyến',
					  @NgaySinh = '1990-01-02',
					  @GioiTinh = 1,
					  @Email = 'nguyenthiduyen@gmail.com',
					  @SoDienThoai = '0955568008';
EXEC sp_GiaoVien_CRUD @Action = 'DELETE',
					  @MaGV = 'GV001';



-- Chèn dữ liệu lớp 6
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 6', '2023-01-8', '6A';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 6', '2023-01-8', '6B';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 6', '2023-01-8', '6C';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 6', '2023-01-8', '6D';

-- Chèn dữ liệu lớp 7
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 7', '2023-01-8', '7A';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 7', '2023-01-8', '7B';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 7', '2023-01-8', '7C';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 7', '2023-01-8', '7D';

-- Chèn dữ liệu lớp 8
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 8', '2023-01-8', '8A';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 8', '2023-01-8', '8B';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 8', '2023-01-8', '8C';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 8', '2023-01-8', '8D';

-- Chèn dữ liệu lớp 9
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 9', '2023-01-8', '9A';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 9', '2023-01-8', '9B';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 9', '2023-01-8', '9C';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 9', '2023-01-8', '9D';

EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 6', '2004-01-22', '6A';
EXEC sp_Lophoc_CRUD 'INSERT', NULL, N'Lớp 7', '1990-01-01', '7A';

EXEC sp_Lophoc_CRUD 'SELECT';
EXEC sp_Lophoc_CRUD 'SELECT_D';
EXEC sp_Lophoc_CRUD   @Action = 'UPDATE',
					  @MaLop = 'ML001',
					  @TenLop = N'Lớp 7',
					  @NamHoc = '1990-01-02',
					  @Khoi = '7A';
EXEC sp_Lophoc_CRUD   @Action = 'DELETE',
					  @MaLop = 'ML001';



-- Học sinh lớp 6A
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Nguyễn Văn A', '2013-01-1', 1, 'ML001';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Trần Thị B', '2013-02-15', 0, 'ML002';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Lê Hoàng C', '2013-03-20', 1, 'ML003';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Phạm Ngọc D', '2013-04-10', 0, 'ML004';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Hoàng Minh E', '2013-05-05', 1, 'ML004';

-- Học sinh lớp 7A
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Vũ Thị F', '2012-06-12', 0, 'ML005';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Đỗ Đức G', '2012-07-28', 1, 'ML005';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Phan Thanh H', '2012-08-08', 1, 'ML006';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Bùi Phương I', '2012-09-22', 0, 'ML007';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Cao Xuân K', '2012-10-18', 1, 'ML008';

-- Học sinh lớp 7A
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Đào Minh Hà', '2011-06-12', 0, 'ML009';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Phan Thị Minh', '2011-07-28', 1, 'ML009';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Nguyễn Thị Huyền Mi', '2011-08-08', 1, 'ML010';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Trần Văn Thanh', '2011-09-22', 0, 'ML011';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Cao Xuân Hiển', '2011-10-18', 1, 'ML012';

-- Học sinh lớp 7A
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Ma Văn Khánh', '2010-06-12', 0, 'ML013';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Nguyễn Thị Xuyến', '2010-07-28', 1, 'ML013';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Bùi Xuân Kiên', '2010-08-08', 1, 'ML014';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Lê Minh', '2010-09-22', 0, 'ML015';
EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Lý Đạt', '2010-10-18', 1, 'ML016';

--EXEC sp_Hocsinh_CRUD 'INSERT', NULL, N'Nguyễn Văn A', '1990-01-01', 1, 'ML001';

EXEC sp_Hocsinh_CRUD 'SELECT';
EXEC sp_Hocsinh_CRUD  @Action = 'SELECT',
					  @TenLop = N'Lớp 6';
EXEC sp_Hocsinh_CRUD  @Action = 'SELECT',
					  @TenLop = N'Lớp 7';
EXEC sp_Hocsinh_CRUD  @Action = 'SELECT',
					  @TenLop = N'Lớp 8';

EXEC sp_Hocsinh_CRUD  @Action = 'SELECT',
					  @TenLop = N'Lớp 6',
					  @Khoi = '6A';
EXEC sp_Hocsinh_CRUD  @Action = 'SELECT',
					  @TenLop = N'Lớp 7';
EXEC sp_Hocsinh_CRUD  @Action = 'SELECT',
					  @TenLop = N'Lớp 8';

EXEC sp_Hocsinh_CRUD  @Action = 'UPDATE',
					  @MaHS = 'HS001',
					  @HoTen = N'Nguyễn Văn B',
					  @NgaySinh = '1990-02-02',
					  @GioiTinh = 0,
					  @MaLop = 'ML002';
EXEC sp_Hocsinh_CRUD  @Action = 'DELETE',
					  @MaHS = 'HS001';



EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Khoa học tự nhiên';
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Khoa học xã hội';
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Khoa học lịch sử';
EXEC sp_Nhommonhoc_CRUD 'SELECT';
EXEC sp_Nhommonhoc_CRUD @Action = 'UPDATE',
					    @MaNhom = 'NM001',
					    @TenNhom = N'Khoa học tự nhiên';
EXEC sp_Nhommonhoc_CRUD @Action = 'DELETE',
					    @MaNhom = 'NM001';


EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Toán', 6, 'NM001';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Vật Lý', 6, 'NM002';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Ngữ Văn', 6, 'NM003';
EXEC sp_Monhoc_CRUD 'SELECT';
EXEC sp_Monhoc_CRUD @Action = 'UPDATE',
					@MaMH = 'MH001',
					@TenMH = N'Vật lý',
					@Khoi = 7,
					@MaNhom = 'NM001';
EXEC sp_Monhoc_CRUD @Action = 'DELETE',
					@MaMH = 'MH020';

-- Chèn dữ liệu nhóm môn học
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Khoa học tự nhiên'; -- NM001
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Khoa học xã hội'; -- NM002
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Ngôn ngữ và Văn học'; -- NM003
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Toán và Tin học'; -- NM004
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Công nghệ và Nghệ thuật'; -- NM005
EXEC sp_Nhommonhoc_CRUD 'INSERT', NULL, N'Giáo dục thể chất và Quốc phòng'; -- NM006

-- Chèn dữ liệu môn học
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Toán', 6, 'NM004';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Ngữ văn', 6, 'NM003';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Ngoại ngữ 1', 6, 'NM003';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Giáo dục công dân', 6, 'NM002';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Lịch sử và Địa lý', 6, 'NM002';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Khoa học tự nhiên', 6, 'NM001';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Công nghệ', 6, 'NM005';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Tin học', 6, 'NM004';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Giáo dục thể chất', 6, 'NM006';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Âm nhạc', 6, 'NM005';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Mỹ thuật', 6, 'NM005';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Vật lý', 7, 'NM001';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Hóa học', 8, 'NM001';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Sinh học', 6, 'NM001';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Lịch sử', 6, 'NM002';
EXEC sp_Monhoc_CRUD 'INSERT', NULL, N'Địa lý', 6, 'NM002';


EXEC sp_Loaidiem_CRUD 'INSERT', NULL, N'Kiểm tra miệng', 1;
EXEC sp_Loaidiem_CRUD 'INSERT', NULL, N'Kiểm tra 15p', 1;
EXEC sp_Loaidiem_CRUD 'INSERT', NULL, N'Kiểm tra 1 tiết', 2;
EXEC sp_Loaidiem_CRUD 'INSERT', NULL, N'Kiểm tra học kỳ', 3;
EXEC sp_Loaidiem_CRUD 'SELECT';
EXEC sp_Loaidiem_CRUD @Action = 'UPDATE',
					  @MaLoaiDiem = 'LD001',
					  @TenLoaiDiem = N'Kiểm tra miệng',
					  @HeSo = 1;
EXEC sp_Loaidiem_CRUD @Action = 'DELETE',
					  @MaLoaiDiem = 'LD001';



EXEC sp_Diem_CRUD 'INSERT', NULL, 'HS001', 'ML001', 'MH001', 'LD001', 9.8, 1, '2019-2020';
EXEC sp_Diem_CRUD 'INSERT', NULL, 'HS002', 'ML001', 'MH001', 'LD001', 9.8, 1, '2019-2020';
EXEC sp_Diem_CRUD 'SELECT';
EXEC sp_Diem_CRUD @Action = 'SELECT',
				  @MaHS = 'HS001';

EXEC sp_Diem_CRUD @Action = 'UPDATE',
				  @MaDiem = 'DS002',
				  @MaHS = 'HS001',
				  @MaLop = 'ML001',
				  @MaMH = 'MH002',
				  @MaLoaiDiem = 'LD001',
				  @Diem = 5;

EXEC sp_Diem_CRUD @Action = 'DELETE',
				  @MaDiem = 'DS001';


EXEC sp_HanhKiem_CRUD 'INSERT', NULL, 'HS001', 'ML001', 1, '2019-2020', 9.8, N'Giỏi', N'Tốt';
EXEC sp_HanhKiem_CRUD 'SELECT';
EXEC sp_HanhKiem_CRUD @Action = 'SELECT',
					  @MaHS = 'HS001';	
EXEC sp_HanhKiem_CRUD @Action = 'UPDATE',
					  @MaHK = 'HK001',
					  @MaHS = 'HS001',
					  @MaLop = 'ML001',
					  @HocKy = 1,
					  @NamHoc = '2019-2020',
					  @DiemTrungBinh = 9,
					  @HocLuc = N'Giỏi',
					  @HanhKiem = N'Tốt';
EXEC sp_HanhKiem_CRUD @Action = 'DELETE',
				      @MaHK = 'HK001';



DECLARE @Result int, @Message nvarchar(255);
EXEC sp_DangNhap 
    @Username = 'user2', 
    @Password = N'123456', -- Mật khẩu gốc
    @Result = @Result OUTPUT, 
    @Message = @Message OUTPUT;
SELECT @Result AS Result, @Message AS Message;

