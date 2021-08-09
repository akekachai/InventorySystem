using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YcgItInventorySystem_V2.Models.Inventory
{
    public partial class YCGInventoryContext : DbContext
    {
        public YCGInventoryContext()
        {
        }

        public YCGInventoryContext(DbContextOptions<YCGInventoryContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Req_FormIt> Req_FormIt { get; set; }
        public virtual DbSet<ReqFormItdetail> ReqFormItdetail { get; set; }
   
        public virtual DbSet<ReqServiceType> ReqServiceType { get; set; }
        public virtual DbSet<InvMstAssetBrand> InvMstAssetBrands { get; set; }
        public virtual DbSet<InvMstAssetCatagory> InvMstAssetCatagories { get; set; }
        public virtual DbSet<InvMstAssetItem> InvMstAssetItems { get; set; }
        public virtual DbSet<InvMstAssetItemSerial> InvMstAssetItemSerials { get; set; }
        public virtual DbSet<InvMstAssetModel> InvMstAssetModels { get; set; }
        public virtual DbSet<InvMstAssetType> InvMstAssetTypes { get; set; }

     
        public virtual DbSet<InvMstEmployeeAssetComment> InvMstEmployeeAssetComments { get; set; }
        public virtual DbSet<InvMstEmployeeAssetItem> InvMstEmployeeAssetItems { get; set; }
        public virtual DbSet<ZempPhoneMobileTab> ZempPhoneMobileTabs { get; set; }
        public virtual DbSet<Zinventory20201218> Zinventory20201218s { get; set; }
        public virtual DbSet<Zinventory20201218Nb> Zinventory20201218Nbs { get; set; }
        public virtual DbSet<Zinventory20201218NbDetail> Zinventory20201218NbDetails { get; set; }
        public virtual DbSet<Zphone> Zphones { get; set; }
        public virtual DbSet<ZphoneJ7> ZphoneJ7s { get; set; }
        public virtual DbSet<Zsim> Zsims { get; set; }
        public virtual DbSet<Ztablet> Ztablets { get; set; }
        public virtual DbSet<Ztemp> Ztemps { get; set; }
        public virtual DbSet<ZtempItem> ZtempItems { get; set; }
        public virtual DbSet<ZtempItemsDtl> ZtempItemsDtls { get; set; }
        public virtual DbSet<ZtempItemsHdr> ZtempItemsHdrs { get; set; }

        public virtual DbSet<SP_EmpHandleAsset> SP_EmpHandleAsset { get; set; }

        public virtual DbSet<SP_ReqFormItList> SP_ReqFormItList { get; set; }

        public virtual DbSet<SP_ReqFormIt_Id> SP_ReqFormIt_Id { get; set; }
        public virtual DbSet<SP_ReqFormItDetailList> SP_ReqFormItDetailList { get; set; }

        public virtual DbSet<SP_EmpHandleAsset_Detail> SP_EmpHandleAsset_Detail { get; set; }
        public virtual DbSet<SP_AssetsRemaining> SP_AssetsRemaining { get; set; }

        public virtual DbSet<SP_Control_Report> SP_Control_Report { get; set; }

        public virtual DbSet<RunningInfo> runningInfo { get; set; }

        public virtual DbSet<SP_InvMstAssetItem_List> sp_InvMstAssetItem_List { get; set; }

        public virtual DbSet<RptInvMstEmployeeAssetItemUsed> RptInvMstEmployeeAssetItemUsed { get; set; }

        public virtual DbSet<RptInvMstAssetItemSerialUsedSelect> RptInvMstAssetItemSerialUsedSelects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AI");

            modelBuilder.Entity<Req_FormIt>(entity =>
                {
                    entity.HasKey(e => e.ReqNo);
                  
                }) ;

            modelBuilder.Entity<RptInvMstAssetItemSerialUsedSelect>(entity =>
            {

                entity.HasKey(e => e.EmployeeId);
                entity.HasKey(e => e.ItemSerialNo);
            });


            modelBuilder.Entity<RptInvMstEmployeeAssetItemUsed>(entity =>
            {
              
                entity.HasKey(e => e.EmployeeId);
              entity.HasKey(e => e.ItemSerialNo);
            });

            modelBuilder.Entity<SP_ReqFormIt_Id>(entity =>
            {
                entity.HasKey(e => e.ReqNo);

            });
            modelBuilder.Entity<SP_EmpHandleAsset_Detail>(entity =>
            {
                entity.HasKey(e => e.EmployeeId );
                entity.HasKey(e => e.ItemSerialNo);
            });

            modelBuilder.Entity<SP_ReqFormItList>(entity =>
            {
                entity.HasKey(e => e.ReqNo);

            });
            modelBuilder.Entity<SP_ReqFormItDetailList>(entity =>
            {
                entity.HasKey(e => e.ReqNo);
                entity.HasKey(e => e.ServiceCode);

            });
            modelBuilder.Entity<InvMstAssetBrand>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.ToTable("InvMstAssetBrand");

                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.BrandDescription).HasMaxLength(200);

                entity.Property(e => e.BrandText).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvMstAssetCatagory>(entity =>
            {
                entity.HasKey(e => e.CatagoryId);

                entity.ToTable("InvMstAssetCatagory");

                entity.Property(e => e.CatagoryId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.CatagoryDescription).HasMaxLength(200);

                entity.Property(e => e.CatagoryText).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SP_EmpHandleAsset>(entity =>
            {
                entity.HasKey(e => e.row_num);

                entity.ToTable("SP_EmpHandleAsset");

            });

            modelBuilder.Entity<InvMstAssetItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("InvMstAssetItem");

                entity.Property(e => e.ItemId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.BrandId).HasMaxLength(10);

                entity.Property(e => e.CatagoryId).HasMaxLength(10);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemContractFlag).HasMaxLength(1);

                entity.Property(e => e.ItemDescription).HasMaxLength(200);

                entity.Property(e => e.ItemExpireDateFlag).HasMaxLength(1);

                entity.Property(e => e.ItemText).HasMaxLength(100);

                entity.Property(e => e.ItemUnlimitFlag).HasMaxLength(1);

                entity.Property(e => e.ModelId).HasMaxLength(10);

                entity.Property(e => e.TypeId).HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvMstAssetItemSerial>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.ItemSerialNo });

                entity.ToTable("InvMstAssetItemSerial");

                entity.Property(e => e.ItemSerialNo).HasMaxLength(200);

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemAssetNo).HasMaxLength(200);

                entity.Property(e => e.ItemContractExpireDate).HasMaxLength(10);

                entity.Property(e => e.ItemContractNo).HasMaxLength(200);

                entity.Property(e => e.ItemContractStartDate).HasMaxLength(10);

                entity.Property(e => e.ItemSerialCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvMstAssetModel>(entity =>
            {
                entity.HasKey(e => e.ModelId);

                entity.ToTable("InvMstAssetModel");

                entity.Property(e => e.ModelId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ModelDescription).HasMaxLength(200);

                entity.Property(e => e.ModelText).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvMstAssetType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("InvMstAssetType");

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.TypeDescription).HasMaxLength(200);

                entity.Property(e => e.TypeText).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<InvMstEmployeeAssetComment>(entity =>
            {
                entity.HasKey(e => new { e.TransactionDate, e.EmployeeId });

                entity.ToTable("InvMstEmployeeAssetComment");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasMaxLength(13);
            });

            modelBuilder.Entity<InvMstEmployeeAssetItem>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("InvMstEmployeeAssetItem");

                entity.Property(e => e.TransactionId).ValueGeneratedNever();

                entity.Property(e => e.ActiveFlag).HasMaxLength(1);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasMaxLength(13);

                entity.Property(e => e.ItemActualDate).HasColumnType("date");

                entity.Property(e => e.ItemReceiveDate).HasColumnType("date");

                entity.Property(e => e.ItemReturnDate).HasColumnType("date");

                entity.Property(e => e.ItemSerialNo).HasMaxLength(200);

                entity.Property(e => e.ItemUserName).HasMaxLength(200);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType).HasMaxLength(2);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ZempPhoneMobileTab>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZEmpPhoneMobileTab");

                entity.Property(e => e.Asset).HasMaxLength(255);

                entity.Property(e => e.Imei)
                    .HasMaxLength(255)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.ผรบผดชอบ)
                    .HasMaxLength(255)
                    .HasColumnName("ผู้รับผิดชอบ");

                entity.Property(e => e.รหส)
                    .HasMaxLength(255)
                    .HasColumnName("รหัส");

                entity.Property(e => e.หมายเลข).HasMaxLength(255);
            });

            modelBuilder.Entity<Zinventory20201218>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZInventory_20201218");

                entity.Property(e => e.Ad)
                    .HasMaxLength(255)
                    .HasColumnName("AD");

                entity.Property(e => e.Cctv)
                    .HasMaxLength(255)
                    .HasColumnName("CCTV");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Email1).HasMaxLength(255);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Lv).HasColumnName("LV#");

                entity.Property(e => e.Nb)
                    .HasMaxLength(255)
                    .HasColumnName("NB");

                entity.Property(e => e.Sap)
                    .HasMaxLength(255)
                    .HasColumnName("SAP");

                entity.Property(e => e.Sn)
                    .HasMaxLength(255)
                    .HasColumnName("SN");

                entity.Property(e => e.Software1).HasMaxLength(255);

                entity.Property(e => e.Software2).HasMaxLength(255);

                entity.Property(e => e.Software3).HasMaxLength(255);

                entity.Property(e => e.Tablet)
                    .HasMaxLength(255)
                    .HasColumnName("Tablet ");

                entity.Property(e => e.TabletAsset)
                    .HasMaxLength(255)
                    .HasColumnName("Tablet Asset");

                entity.Property(e => e.ชอ)
                    .HasMaxLength(255)
                    .HasColumnName("ชื่อ");

                entity.Property(e => e.ตำหน)
                    .HasMaxLength(255)
                    .HasColumnName("ตำหนิ");

                entity.Property(e => e.ตำแหนง)
                    .HasMaxLength(255)
                    .HasColumnName("ตำแหน่ง");

                entity.Property(e => e.นามสกล)
                    .HasMaxLength(255)
                    .HasColumnName("นามสกุล");

                entity.Property(e => e.ยหอ)
                    .HasMaxLength(255)
                    .HasColumnName("ยี่ห่อ");

                entity.Property(e => e.รน)
                    .HasMaxLength(255)
                    .HasColumnName("รุ่น");

                entity.Property(e => e.รหส).HasColumnName("รหัส");

                entity.Property(e => e.สถานะ).HasMaxLength(255);

                entity.Property(e => e.สนสดสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("สิ้นสุดสัญญา");

                entity.Property(e => e.สายงาน).HasMaxLength(255);

                entity.Property(e => e.เบอรOffice)
                    .HasMaxLength(255)
                    .HasColumnName("เบอร์ Office");

                entity.Property(e => e.เรมสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("เริ่มสัญญา");

                entity.Property(e => e.เลขทสญญา)
                    .HasMaxLength(255)
                    .HasColumnName("เลขที่สัญญา");

                entity.Property(e => e.แผนก).HasMaxLength(255);
            });

            modelBuilder.Entity<Zinventory20201218Nb>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZInventory_20201218_NB");

                entity.Property(e => e.Nb)
                    .HasMaxLength(255)
                    .HasColumnName("NB");

                entity.Property(e => e.Sn)
                    .HasMaxLength(255)
                    .HasColumnName("SN");

                entity.Property(e => e.ยหอ)
                    .HasMaxLength(255)
                    .HasColumnName("ยี่ห่อ");

                entity.Property(e => e.รน)
                    .HasMaxLength(255)
                    .HasColumnName("รุ่น");

                entity.Property(e => e.สนสดสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("สิ้นสุดสัญญา");

                entity.Property(e => e.สนสดสญญาคศ)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("สิ้นสุดสัญญา_คศ");

                entity.Property(e => e.เรมสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("เริ่มสัญญา");

                entity.Property(e => e.เรมสญญาคศ)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("เริ่มสัญญา_คศ");

                entity.Property(e => e.เลขทสญญา)
                    .HasMaxLength(255)
                    .HasColumnName("เลขที่สัญญา");
            });

            modelBuilder.Entity<Zinventory20201218NbDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZInventory_20201218_NB_Detail");

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BrandId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CatagoryId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemContractFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemExpireDateFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemText)
                    .IsRequired()
                    .HasMaxLength(511);

                entity.Property(e => e.ItemUnlimitFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ModelId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nb)
                    .HasMaxLength(255)
                    .HasColumnName("NB");

                entity.Property(e => e.Sn)
                    .HasMaxLength(255)
                    .HasColumnName("SN");

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.ยหอ)
                    .HasMaxLength(255)
                    .HasColumnName("ยี่ห่อ");

                entity.Property(e => e.รน)
                    .HasMaxLength(255)
                    .HasColumnName("รุ่น");

                entity.Property(e => e.สนสดสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("สิ้นสุดสัญญา");

                entity.Property(e => e.สนสดสญญาคศ)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("สิ้นสุดสัญญา_คศ");

                entity.Property(e => e.เรมสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("เริ่มสัญญา");

                entity.Property(e => e.เรมสญญาคศ)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("เริ่มสัญญา_คศ");

                entity.Property(e => e.เลขทสญญา)
                    .HasMaxLength(255)
                    .HasColumnName("เลขที่สัญญา");
            });

            modelBuilder.Entity<Zphone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZPhone");

                entity.Property(e => e.Eimi)
                    .HasMaxLength(255)
                    .HasColumnName("EIMI");

                entity.Property(e => e.ชอ)
                    .HasMaxLength(255)
                    .HasColumnName("ชื่อ");

                entity.Property(e => e.รหส).HasColumnName("รหัส");

                entity.Property(e => e.รหสทรพยสน)
                    .HasMaxLength(255)
                    .HasColumnName("รหัสทรัพย์สิน");

                entity.Property(e => e.รายละเอยด)
                    .HasMaxLength(255)
                    .HasColumnName("รายละเอียด");
            });

            modelBuilder.Entity<ZphoneJ7>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZPhoneJ7");

                entity.Property(e => e.Eimi)
                    .HasMaxLength(255)
                    .HasColumnName("EIMI");

                entity.Property(e => e.ชอ)
                    .HasMaxLength(255)
                    .HasColumnName("ชื่อ");

                entity.Property(e => e.รหส)
                    .HasMaxLength(255)
                    .HasColumnName("รหัส");

                entity.Property(e => e.รหสทรพยสน)
                    .HasMaxLength(255)
                    .HasColumnName("รหัสทรัพย์สิน");

                entity.Property(e => e.รายละเอยด)
                    .HasMaxLength(255)
                    .HasColumnName("รายละเอียด");
            });

            modelBuilder.Entity<Zsim>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Zsim");

                entity.Property(e => e.ชอ)
                    .HasMaxLength(255)
                    .HasColumnName("ชื่อ");

                entity.Property(e => e.รหสพนกงาน).HasColumnName("รหัสพนักงาน");

                entity.Property(e => e.หมดสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("หมดสัญญา");

                entity.Property(e => e.เบอร)
                    .HasMaxLength(255)
                    .HasColumnName("เบอร์");

                entity.Property(e => e.เรมสญญา)
                    .HasColumnType("datetime")
                    .HasColumnName("เริ่มสัญญา");
            });

            modelBuilder.Entity<Ztablet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZTablet");

                entity.Property(e => e.Eimi)
                    .HasMaxLength(255)
                    .HasColumnName("EIMI");

                entity.Property(e => e.ชอ)
                    .HasMaxLength(255)
                    .HasColumnName("ชื่อ");

                entity.Property(e => e.รหส).HasColumnName("รหัส");

                entity.Property(e => e.รหสทรพยสน).HasColumnName("รหัสทรัพย์สิน");

                entity.Property(e => e.รายละเอยด)
                    .HasMaxLength(255)
                    .HasColumnName("รายละเอียด");

                entity.Property(e => e.สนสด)
                    .HasColumnType("datetime")
                    .HasColumnName("สิ้นสุด");

                entity.Property(e => e.เบอรโทร)
                    .HasMaxLength(255)
                    .HasColumnName("เบอร์โทร");

                entity.Property(e => e.เรม)
                    .HasColumnType("datetime")
                    .HasColumnName("เริ่ม");
            });

            modelBuilder.Entity<Ztemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZTemp");

                entity.Property(e => e.Col1).HasMaxLength(50);

                entity.Property(e => e.Col2).HasMaxLength(50);

                entity.Property(e => e.Col3).HasMaxLength(50);

                entity.Property(e => e.Col4).HasMaxLength(50);

                entity.Property(e => e.Col5).HasMaxLength(50);

                entity.Property(e => e.Col6).HasMaxLength(50);

                entity.Property(e => e.Col7).HasColumnType("date");

                entity.Property(e => e.Col8).HasColumnType("date");
            });

            modelBuilder.Entity<ZtempItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZTempItems");

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Col3).HasMaxLength(50);

                entity.Property(e => e.Col4).HasMaxLength(50);

                entity.Property(e => e.Col5).HasMaxLength(50);

                entity.Property(e => e.Col6).HasMaxLength(50);

                entity.Property(e => e.Col7).HasColumnType("date");

                entity.Property(e => e.Col8).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Div)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("DIV");

                entity.Property(e => e.DtlActiveFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Dtl_ActiveFlag");

                entity.Property(e => e.DtlCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Dtl_CreateDate");

                entity.Property(e => e.DtlCreateUserId).HasColumnName("Dtl_CreateUserId");

                entity.Property(e => e.DtlItemAssetNo)
                    .HasMaxLength(50)
                    .HasColumnName("Dtl_ItemAssetNo");

                entity.Property(e => e.DtlItemAvailableQty).HasColumnName("Dtl_ItemAvailableQty");

                entity.Property(e => e.DtlItemContractExpireDate)
                    .HasColumnType("date")
                    .HasColumnName("Dtl_ItemContractExpireDate");

                entity.Property(e => e.DtlItemContractNo)
                    .HasMaxLength(50)
                    .HasColumnName("Dtl_ItemContractNo");

                entity.Property(e => e.DtlItemContractStartDate)
                    .HasColumnType("date")
                    .HasColumnName("Dtl_ItemContractStartDate");

                entity.Property(e => e.DtlItemId).HasColumnName("Dtl_ItemId");

                entity.Property(e => e.DtlItemSerialCost).HasColumnName("Dtl_ItemSerialCost");

                entity.Property(e => e.DtlItemSerialNo)
                    .HasMaxLength(50)
                    .HasColumnName("Dtl_ItemSerialNo");

                entity.Property(e => e.DtlUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Dtl_UpdateDate");

                entity.Property(e => e.DtlUpdateUserId).HasColumnName("Dtl_UpdateUserId");

                entity.Property(e => e.ItemContractFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemExpireDateFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemText)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.ItemUnlimitFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ZtempItemsDtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZTempItemsDTL");

                entity.Property(e => e.DtlActiveFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Dtl_ActiveFlag");

                entity.Property(e => e.DtlCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Dtl_CreateDate");

                entity.Property(e => e.DtlCreateUserId).HasColumnName("Dtl_CreateUserId");

                entity.Property(e => e.DtlItemAssetNo)
                    .HasMaxLength(50)
                    .HasColumnName("Dtl_ItemAssetNo");

                entity.Property(e => e.DtlItemAvailableQty).HasColumnName("Dtl_ItemAvailableQty");

                entity.Property(e => e.DtlItemContractExpireDate)
                    .HasColumnType("date")
                    .HasColumnName("Dtl_ItemContractExpireDate");

                entity.Property(e => e.DtlItemContractNo)
                    .HasMaxLength(50)
                    .HasColumnName("Dtl_ItemContractNo");

                entity.Property(e => e.DtlItemContractStartDate)
                    .HasColumnType("date")
                    .HasColumnName("Dtl_ItemContractStartDate");

                entity.Property(e => e.DtlItemSerialCost).HasColumnName("Dtl_ItemSerialCost");

                entity.Property(e => e.DtlItemSerialNo)
                    .HasMaxLength(50)
                    .HasColumnName("Dtl_ItemSerialNo");

                entity.Property(e => e.DtlUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Dtl_UpdateDate");

                entity.Property(e => e.DtlUpdateUserId).HasColumnName("Dtl_UpdateUserId");
            });

            modelBuilder.Entity<ZtempItemsHdr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ZTempItemsHdr");

                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemContractFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemExpireDateFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ItemText)
                    .IsRequired()
                    .HasMaxLength(101);

                entity.Property(e => e.ItemUnlimitFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

          

            modelBuilder.Entity<ReqFormItdetail>(entity =>
            {
                entity.HasKey(e => new { e.ReqNo, e.ServiceCode })
                    .HasName("PK_Req_Details");

                entity.ToTable("Req_FormITDetails");

                entity.Property(e => e.ReqNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Actions)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssetCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Brand)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IMEINo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMEINo");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReqServiceType>(entity =>
            {
                entity.HasKey(e => e.ServiceCode);

                entity.ToTable("Req_ServiceType");

                entity.Property(e => e.ServiceCode).HasDefaultValueSql("((1))");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
