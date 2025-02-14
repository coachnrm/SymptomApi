using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace SymptomApi.Model2s;

public partial class HosXpDbContext : DbContext
{
    public HosXpDbContext()
    {
    }

    public HosXpDbContext(DbContextOptions<HosXpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Opdscreen> Opdscreens { get; set; }

    public virtual DbSet<VnStat> VnStats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=172.16.5.39;port=3306;database=hos;userid=hks;password=\"Fi'rpk[k]@!#\"", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.1.37-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("tis620_thai_ci")
            .HasCharSet("tis620");

        modelBuilder.Entity<Opdscreen>(entity =>
        {
            entity.HasKey(e => e.HosGuid).HasName("PRIMARY");

            entity.ToTable("opdscreen");

            entity.HasIndex(e => e.Bw, "ix_bw");

            entity.HasIndex(e => e.Hn, "ix_hn");

            entity.HasIndex(e => new { e.Height, e.Hn }, "ix_hn_height");

            entity.HasIndex(e => e.Vn, "ix_vn_unique").IsUnique();

            entity.HasIndex(e => e.Vstdate, "ix_vstdate");

            entity.Property(e => e.HosGuid)
                .HasMaxLength(38)
                .HasColumnName("hos_guid");
            entity.Property(e => e.AdherencePercent)
                .HasColumnType("double(15,3)")
                .HasColumnName("adherence_percent");
            entity.Property(e => e.Advice1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice1");
            entity.Property(e => e.Advice2)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice2");
            entity.Property(e => e.Advice3)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice3");
            entity.Property(e => e.Advice4)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice4");
            entity.Property(e => e.Advice5)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice5");
            entity.Property(e => e.Advice6)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice6");
            entity.Property(e => e.Advice7)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice7");
            entity.Property(e => e.Advice7Note)
                .HasMaxLength(250)
                .HasColumnName("advice7_note");
            entity.Property(e => e.Advice8)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("advice8");
            entity.Property(e => e.Alt)
                .HasColumnType("double(15,3)")
                .HasColumnName("alt");
            entity.Property(e => e.Ambu)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ambu");
            entity.Property(e => e.Ast)
                .HasColumnType("double(15,3)")
                .HasColumnName("ast");
            entity.Property(e => e.Begintime)
                .HasColumnType("time")
                .HasColumnName("begintime");
            entity.Property(e => e.Bicarb)
                .HasColumnType("double(15,3)")
                .HasColumnName("bicarb");
            entity.Property(e => e.Blank1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("blank1");
            entity.Property(e => e.Bmi)
                .HasColumnType("double(15,3)")
                .HasColumnName("bmi");
            entity.Property(e => e.BpStable)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("bp_stable");
            entity.Property(e => e.Bpd)
                .HasColumnType("double(15,3)")
                .HasColumnName("bpd");
            entity.Property(e => e.Bps)
                .HasColumnType("double(15,3)")
                .HasColumnName("bps");
            entity.Property(e => e.BreastFeeding)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("breast_feeding");
            entity.Property(e => e.Bsa)
                .HasColumnType("double(15,3)")
                .HasColumnName("bsa");
            entity.Property(e => e.Bun)
                .HasColumnType("double(15,3)")
                .HasColumnName("bun");
            entity.Property(e => e.Bw)
                .HasColumnType("double(15,3)")
                .HasColumnName("bw");
            entity.Property(e => e.Cc)
                .HasColumnType("text")
                .HasColumnName("cc");
            entity.Property(e => e.CcBeginDate).HasColumnName("cc_begin_date");
            entity.Property(e => e.CcCauseOfVisit)
                .HasMaxLength(250)
                .HasColumnName("cc_cause_of_visit");
            entity.Property(e => e.CcDuration)
                .HasMaxLength(150)
                .HasColumnName("cc_duration");
            entity.Property(e => e.CcNote)
                .HasColumnType("text")
                .HasColumnName("cc_note");
            entity.Property(e => e.CcPosition)
                .HasMaxLength(250)
                .HasColumnName("cc_position");
            entity.Property(e => e.CcSign)
                .HasMaxLength(250)
                .HasColumnName("cc_sign");
            entity.Property(e => e.Checkup)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("checkup");
            entity.Property(e => e.Chloride)
                .HasColumnType("double(15,3)")
                .HasColumnName("chloride");
            entity.Property(e => e.Cholesterol)
                .HasColumnType("double(15,3)")
                .HasColumnName("cholesterol");
            entity.Property(e => e.Cradle)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("cradle");
            entity.Property(e => e.CradleLie)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("cradle_lie");
            entity.Property(e => e.Creatinine)
                .HasColumnType("double(15,3)")
                .HasColumnName("creatinine");
            entity.Property(e => e.CreatinineKidneyPercent)
                .HasColumnType("double(15,3)")
                .HasColumnName("creatinine_kidney_percent");
            entity.Property(e => e.DevelopmentScreenTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("development_screen_type_id");
            entity.Property(e => e.DrinkingTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("drinking_type_id");
            entity.Property(e => e.Egfr)
                .HasColumnType("double(15,3)")
                .HasColumnName("egfr");
            entity.Property(e => e.Endtime)
                .HasColumnType("time")
                .HasColumnName("endtime");
            entity.Property(e => e.ErNote)
                .HasColumnType("text")
                .HasColumnName("er_note");
            entity.Property(e => e.Fbs)
                .HasColumnType("double(15,3)")
                .HasColumnName("fbs");
            entity.Property(e => e.Fev1Fevc)
                .HasColumnType("double(15,3)")
                .HasColumnName("fev1_fevc");
            entity.Property(e => e.Fev1Percent)
                .HasColumnType("double(15,3)")
                .HasColumnName("fev1_percent");
            entity.Property(e => e.Fh)
                .HasColumnType("text")
                .HasColumnName("fh");
            entity.Property(e => e.FoundAllergy)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("found_allergy");
            entity.Property(e => e.FoundAmphetamine)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("found_amphetamine");
            entity.Property(e => e.G6pd)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("g6pd");
            entity.Property(e => e.Glucurine)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("glucurine");
            entity.Property(e => e.Hb)
                .HasColumnType("double(15,3)")
                .HasColumnName("hb");
            entity.Property(e => e.Hba1c)
                .HasColumnType("double(15,3)")
                .HasColumnName("hba1c");
            entity.Property(e => e.Hdl)
                .HasColumnType("double(15,3)")
                .HasColumnName("hdl");
            entity.Property(e => e.HeadCricumference)
                .HasColumnType("double(15,2)")
                .HasColumnName("head_cricumference");
            entity.Property(e => e.Height)
                .HasColumnType("int(11)")
                .HasColumnName("height");
            entity.Property(e => e.Help1)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("help1");
            entity.Property(e => e.Help1Bpd)
                .HasColumnType("int(11)")
                .HasColumnName("help1_bpd");
            entity.Property(e => e.Help1Bps)
                .HasColumnType("int(11)")
                .HasColumnName("help1_bps");
            entity.Property(e => e.Help1Time)
                .HasColumnType("time")
                .HasColumnName("help1_time");
            entity.Property(e => e.Help2)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("help2");
            entity.Property(e => e.Help2Temp)
                .HasColumnType("double(15,3)")
                .HasColumnName("help2_temp");
            entity.Property(e => e.Help2Time)
                .HasColumnType("time")
                .HasColumnName("help2_time");
            entity.Property(e => e.Help3)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("help3");
            entity.Property(e => e.Help3Icode)
                .HasMaxLength(100)
                .HasColumnName("help3_icode");
            entity.Property(e => e.Help3Qty)
                .HasColumnType("tinyint(4)")
                .HasColumnName("help3_qty");
            entity.Property(e => e.Help3Time)
                .HasColumnType("time")
                .HasColumnName("help3_time");
            entity.Property(e => e.Help4)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("help4");
            entity.Property(e => e.Help4Note)
                .HasColumnType("text")
                .HasColumnName("help4_note");
            entity.Property(e => e.HisBeginDate).HasColumnName("his_begin_date");
            entity.Property(e => e.HisCause)
                .HasMaxLength(250)
                .HasColumnName("his_cause");
            entity.Property(e => e.HisCauseDecrease)
                .HasMaxLength(250)
                .HasColumnName("his_cause_decrease");
            entity.Property(e => e.HisCauseIncrease)
                .HasMaxLength(250)
                .HasColumnName("his_cause_increase");
            entity.Property(e => e.HisExpand)
                .HasMaxLength(250)
                .HasColumnName("his_expand");
            entity.Property(e => e.HisFrequency)
                .HasMaxLength(250)
                .HasColumnName("his_frequency");
            entity.Property(e => e.HisRelatedSign)
                .HasMaxLength(250)
                .HasColumnName("his_related_sign");
            entity.Property(e => e.HisSeverity)
                .HasMaxLength(250)
                .HasColumnName("his_severity");
            entity.Property(e => e.Hn)
                .HasMaxLength(9)
                .HasColumnName("hn");
            entity.Property(e => e.Hpi)
                .HasColumnType("text")
                .HasColumnName("hpi");
            entity.Property(e => e.Hr)
                .HasColumnType("double(15,3)")
                .HasColumnName("hr");
            entity.Property(e => e.Ldl)
                .HasColumnType("double(15,3)")
                .HasColumnName("ldl");
            entity.Property(e => e.LmpDate).HasColumnName("lmp_date");
            entity.Property(e => e.MacroAlbumin)
                .HasColumnType("int(11)")
                .HasColumnName("macro_albumin");
            entity.Property(e => e.MenstrualCycleTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("menstrual_cycle_type_id");
            entity.Property(e => e.MicroAlbumin)
                .HasColumnType("int(11)")
                .HasColumnName("micro_albumin");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.O2sat)
                .HasColumnType("int(11)")
                .HasColumnName("o2sat");
            entity.Property(e => e.OpdscreenBpLocTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("opdscreen_bp_loc_type_id");
            entity.Property(e => e.OpdscreenPatientTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("opdscreen_patient_type_id");
            entity.Property(e => e.Outtime)
                .HasColumnType("time")
                .HasColumnName("outtime");
            entity.Property(e => e.PainScore)
                .HasColumnType("int(11)")
                .HasColumnName("pain_score");
            entity.Property(e => e.Pe)
                .HasColumnType("text")
                .HasColumnName("pe");
            entity.Property(e => e.PeAb)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_ab");
            entity.Property(e => e.PeAbText)
                .HasMaxLength(250)
                .HasColumnName("pe_ab_text");
            entity.Property(e => e.PeChest)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_chest");
            entity.Property(e => e.PeChestText)
                .HasMaxLength(150)
                .HasColumnName("pe_chest_text");
            entity.Property(e => e.PeExt)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_ext");
            entity.Property(e => e.PeExtText)
                .HasMaxLength(250)
                .HasColumnName("pe_ext_text");
            entity.Property(e => e.PeGa)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_ga");
            entity.Property(e => e.PeGaText)
                .HasMaxLength(250)
                .HasColumnName("pe_ga_text");
            entity.Property(e => e.PeGen)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_gen");
            entity.Property(e => e.PeGenText)
                .HasMaxLength(250)
                .HasColumnName("pe_gen_text");
            entity.Property(e => e.PeGi)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_gi");
            entity.Property(e => e.PeGiText)
                .HasMaxLength(250)
                .HasColumnName("pe_gi_text");
            entity.Property(e => e.PeGu)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_gu");
            entity.Property(e => e.PeGuText)
                .HasMaxLength(250)
                .HasColumnName("pe_gu_text");
            entity.Property(e => e.PeGy)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_gy");
            entity.Property(e => e.PeGyText)
                .HasMaxLength(250)
                .HasColumnName("pe_gy_text");
            entity.Property(e => e.PeHead)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_head");
            entity.Property(e => e.PeHeadText)
                .HasMaxLength(250)
                .HasColumnName("pe_head_text");
            entity.Property(e => e.PeHeart)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_heart");
            entity.Property(e => e.PeHeartText)
                .HasMaxLength(250)
                .HasColumnName("pe_heart_text");
            entity.Property(e => e.PeHeent)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_heent");
            entity.Property(e => e.PeHeentText)
                .HasMaxLength(250)
                .HasColumnName("pe_heent_text");
            entity.Property(e => e.PeLung)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_lung");
            entity.Property(e => e.PeLungText)
                .HasMaxLength(250)
                .HasColumnName("pe_lung_text");
            entity.Property(e => e.PeNeuro)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_neuro");
            entity.Property(e => e.PeNeuroText)
                .HasMaxLength(250)
                .HasColumnName("pe_neuro_text");
            entity.Property(e => e.PePr)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_pr");
            entity.Property(e => e.PePrText)
                .HasMaxLength(250)
                .HasColumnName("pe_pr_text");
            entity.Property(e => e.PePv)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_pv");
            entity.Property(e => e.PePvText)
                .HasMaxLength(250)
                .HasColumnName("pe_pv_text");
            entity.Property(e => e.PeRtf).HasColumnName("pe_rtf");
            entity.Property(e => e.PeRtfBlob).HasColumnName("pe_rtf_blob");
            entity.Property(e => e.PeSkin)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pe_skin");
            entity.Property(e => e.PeSkinText)
                .HasMaxLength(250)
                .HasColumnName("pe_skin_text");
            entity.Property(e => e.PeakFlow)
                .HasColumnType("int(11)")
                .HasColumnName("peak_flow");
            entity.Property(e => e.Pefr)
                .HasColumnType("int(11)")
                .HasColumnName("pefr");
            entity.Property(e => e.PefrPercent)
                .HasColumnType("double(15,3)")
                .HasColumnName("pefr_percent");
            entity.Property(e => e.Phosphate)
                .HasColumnType("double(15,3)")
                .HasColumnName("phosphate");
            entity.Property(e => e.Pmh)
                .HasColumnType("text")
                .HasColumnName("pmh");
            entity.Property(e => e.PostPainScore)
                .HasColumnType("int(11)")
                .HasColumnName("post_pain_score");
            entity.Property(e => e.Potassium)
                .HasColumnType("double(15,3)")
                .HasColumnName("potassium");
            entity.Property(e => e.PrePainScore)
                .HasColumnType("int(11)")
                .HasColumnName("pre_pain_score");
            entity.Property(e => e.Pregnancy)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pregnancy");
            entity.Property(e => e.Pth)
                .HasColumnType("double(15,3)")
                .HasColumnName("pth");
            entity.Property(e => e.Pulse)
                .HasColumnType("double(15,3)")
                .HasColumnName("pulse");
            entity.Property(e => e.PulseRegulationTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("pulse_regulation_type_id");
            entity.Property(e => e.Riskdm)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("riskdm");
            entity.Property(e => e.Ros)
                .HasColumnType("text")
                .HasColumnName("ros");
            entity.Property(e => e.Rr)
                .HasColumnType("double(15,3)")
                .HasColumnName("rr");
            entity.Property(e => e.ScreenDep)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("screen_dep");
            entity.Property(e => e.Sh)
                .HasColumnType("text")
                .HasColumnName("sh");
            entity.Property(e => e.SkinColor)
                .HasMaxLength(20)
                .HasColumnName("skin_color");
            entity.Property(e => e.SmokingTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("smoking_type_id");
            entity.Property(e => e.Sodium)
                .HasColumnType("double(15,3)")
                .HasColumnName("sodium");
            entity.Property(e => e.Spo2)
                .HasColumnType("double(15,3)")
                .HasColumnName("spo2");
            entity.Property(e => e.Symptom)
                .HasMaxLength(200)
                .HasColumnName("symptom");
            entity.Property(e => e.Tc)
                .HasColumnType("double(15,3)")
                .HasColumnName("tc");
            entity.Property(e => e.Tco2)
                .HasColumnType("double(15,3)")
                .HasColumnName("tco2");
            entity.Property(e => e.Temperature)
                .HasColumnType("double(15,3)")
                .HasColumnName("temperature");
            entity.Property(e => e.Tg)
                .HasColumnType("double(15,3)")
                .HasColumnName("tg");
            entity.Property(e => e.Ua)
                .HasColumnType("double(15,3)")
                .HasColumnName("ua");
            entity.Property(e => e.Upcr)
                .HasColumnType("double(15,3)")
                .HasColumnName("upcr");
            entity.Property(e => e.UpdateDatetime)
                .HasColumnType("datetime")
                .HasColumnName("update_datetime");
            entity.Property(e => e.UrineAlbumin)
                .HasColumnType("double(15,3)")
                .HasColumnName("urine_albumin");
            entity.Property(e => e.UrineCreatinine)
                .HasColumnType("double(15,3)")
                .HasColumnName("urine_creatinine");
            entity.Property(e => e.VaccineScreenTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("vaccine_screen_type_id");
            entity.Property(e => e.Vn)
                .HasMaxLength(13)
                .HasColumnName("vn");
            entity.Property(e => e.Vstdate).HasColumnName("vstdate");
            entity.Property(e => e.Vsttime)
                .HasColumnType("time")
                .HasColumnName("vsttime");
            entity.Property(e => e.Waist)
                .HasColumnType("double(15,3)")
                .HasColumnName("waist");
            entity.Property(e => e.Waiting)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("waiting");
            entity.Property(e => e.WalkId)
                .HasColumnType("int(11)")
                .HasColumnName("walk_id");
        });

        modelBuilder.Entity<VnStat>(entity =>
        {
            entity.HasKey(e => e.Vn).HasName("PRIMARY");

            entity.ToTable("vn_stat");

            entity.HasIndex(e => e.Cid, "ix_cid");

            entity.HasIndex(e => e.Hn, "ix_hn");

            entity.HasIndex(e => e.HosGuid, "ix_hos_guid");

            entity.HasIndex(e => e.Hospmain, "ix_hospmain");

            entity.HasIndex(e => e.Hospsub, "ix_hospsub");

            entity.HasIndex(e => e.Pcode, "ix_pcode");

            entity.HasIndex(e => e.Pttype, "ix_pttype");

            entity.HasIndex(e => e.Vstdate, "ix_vstdate");

            entity.HasIndex(e => e.Ym, "ix_ym");

            entity.Property(e => e.Vn)
                .HasMaxLength(13)
                .HasColumnName("vn");
            entity.Property(e => e.AccidentCode)
                .HasMaxLength(6)
                .HasColumnName("accident_code");
            entity.Property(e => e.AgeD)
                .HasColumnType("smallint(6)")
                .HasColumnName("age_d");
            entity.Property(e => e.AgeM)
                .HasColumnType("smallint(6)")
                .HasColumnName("age_m");
            entity.Property(e => e.AgeY)
                .HasColumnType("smallint(6)")
                .HasColumnName("age_y");
            entity.Property(e => e.Aid)
                .HasMaxLength(6)
                .HasColumnName("aid");
            entity.Property(e => e.ArTransferDatetimeSk)
                .HasColumnType("datetime")
                .HasColumnName("ar_transfer_datetime_sk");
            entity.Property(e => e.ArTransferSk)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ar_transfer_sk");
            entity.Property(e => e.ArTransferStaffSk)
                .HasMaxLength(25)
                .HasColumnName("ar_transfer_staff_sk");
            entity.Property(e => e.Cid)
                .HasMaxLength(13)
                .HasColumnName("cid");
            entity.Property(e => e.CountInDay)
                .HasColumnType("tinyint(4)")
                .HasColumnName("count_in_day");
            entity.Property(e => e.CountInMonth)
                .HasColumnType("smallint(6)")
                .HasColumnName("count_in_month");
            entity.Property(e => e.CountInYear)
                .HasColumnType("smallint(6)")
                .HasColumnName("count_in_year");
            entity.Property(e => e.Dba)
                .HasColumnType("tinyint(4)")
                .HasColumnName("dba");
            entity.Property(e => e.DebtIdList)
                .HasMaxLength(50)
                .HasColumnName("debt_id_list");
            entity.Property(e => e.DiscountMoney)
                .HasColumnType("double(15,3)")
                .HasColumnName("discount_money");
            entity.Property(e => e.Dx0)
                .HasMaxLength(6)
                .HasColumnName("dx0");
            entity.Property(e => e.Dx1)
                .HasMaxLength(6)
                .HasColumnName("dx1");
            entity.Property(e => e.Dx2)
                .HasMaxLength(6)
                .HasColumnName("dx2");
            entity.Property(e => e.Dx3)
                .HasMaxLength(6)
                .HasColumnName("dx3");
            entity.Property(e => e.Dx4)
                .HasMaxLength(6)
                .HasColumnName("dx4");
            entity.Property(e => e.Dx5)
                .HasMaxLength(6)
                .HasColumnName("dx5");
            entity.Property(e => e.DxDoctor)
                .HasMaxLength(7)
                .HasColumnName("dx_doctor");
            entity.Property(e => e.Gr504)
                .HasColumnType("smallint(6)")
                .HasColumnName("gr504");
            entity.Property(e => e.Hcode)
                .HasMaxLength(5)
                .HasColumnName("hcode");
            entity.Property(e => e.Hn)
                .HasMaxLength(9)
                .HasColumnName("hn");
            entity.Property(e => e.HosGuid)
                .HasMaxLength(38)
                .HasColumnName("hos_guid");
            entity.Property(e => e.Hospmain)
                .HasMaxLength(5)
                .HasColumnName("hospmain");
            entity.Property(e => e.Hospsub)
                .HasMaxLength(5)
                .HasColumnName("hospsub");
            entity.Property(e => e.IllVisit)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("ill_visit");
            entity.Property(e => e.Inc01)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc01");
            entity.Property(e => e.Inc02)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc02");
            entity.Property(e => e.Inc03)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc03");
            entity.Property(e => e.Inc04)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc04");
            entity.Property(e => e.Inc05)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc05");
            entity.Property(e => e.Inc06)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc06");
            entity.Property(e => e.Inc07)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc07");
            entity.Property(e => e.Inc08)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc08");
            entity.Property(e => e.Inc09)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc09");
            entity.Property(e => e.Inc10)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc10");
            entity.Property(e => e.Inc11)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc11");
            entity.Property(e => e.Inc12)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc12");
            entity.Property(e => e.Inc13)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc13");
            entity.Property(e => e.Inc14)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc14");
            entity.Property(e => e.Inc15)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc15");
            entity.Property(e => e.Inc16)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc16");
            entity.Property(e => e.Inc17)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc17");
            entity.Property(e => e.IncDrug)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc_drug");
            entity.Property(e => e.IncNondrug)
                .HasColumnType("double(15,3)")
                .HasColumnName("inc_nondrug");
            entity.Property(e => e.Income)
                .HasColumnType("double(15,3)")
                .HasColumnName("income");
            entity.Property(e => e.ItemMoney)
                .HasColumnType("double(15,3)")
                .HasColumnName("item_money");
            entity.Property(e => e.LabPaidOk)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("lab_paid_ok");
            entity.Property(e => e.Lastvisit)
                .HasColumnType("smallint(6)")
                .HasColumnName("lastvisit");
            entity.Property(e => e.LastvisitHour)
                .HasColumnType("int(11)")
                .HasColumnName("lastvisit_hour");
            entity.Property(e => e.LastvisitVn)
                .HasMaxLength(13)
                .HasColumnName("lastvisit_vn");
            entity.Property(e => e.MainPdx)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("main_pdx");
            entity.Property(e => e.Moopart)
                .HasMaxLength(5)
                .HasColumnName("moopart");
            entity.Property(e => e.NodeId)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("node_id");
            entity.Property(e => e.OldDiagnosis)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("old_diagnosis");
            entity.Property(e => e.Op0)
                .HasMaxLength(6)
                .HasColumnName("op0");
            entity.Property(e => e.Op1)
                .HasMaxLength(6)
                .HasColumnName("op1");
            entity.Property(e => e.Op2)
                .HasMaxLength(6)
                .HasColumnName("op2");
            entity.Property(e => e.Op3)
                .HasMaxLength(6)
                .HasColumnName("op3");
            entity.Property(e => e.Op4)
                .HasMaxLength(6)
                .HasColumnName("op4");
            entity.Property(e => e.Op5)
                .HasMaxLength(6)
                .HasColumnName("op5");
            entity.Property(e => e.PaidMoney)
                .HasColumnType("double(15,3)")
                .HasColumnName("paid_money");
            entity.Property(e => e.Pcode)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("pcode");
            entity.Property(e => e.Pdx)
                .HasMaxLength(6)
                .HasColumnName("pdx");
            entity.Property(e => e.PrintCount)
                .HasColumnType("tinyint(4)")
                .HasColumnName("print_count");
            entity.Property(e => e.PrintDone)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("print_done");
            entity.Property(e => e.PtSubtype)
                .HasColumnType("tinyint(4)")
                .HasColumnName("pt_subtype");
            entity.Property(e => e.Pttype)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("pttype");
            entity.Property(e => e.PttypeBegin).HasColumnName("pttype_begin");
            entity.Property(e => e.PttypeExpire).HasColumnName("pttype_expire");
            entity.Property(e => e.PttypeInChwpart)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pttype_in_chwpart");
            entity.Property(e => e.PttypeInRegion)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("pttype_in_region");
            entity.Property(e => e.Pttypeno)
                .HasMaxLength(20)
                .HasColumnName("pttypeno");
            entity.Property(e => e.RcpNo)
                .HasMaxLength(10)
                .HasColumnName("rcp_no");
            entity.Property(e => e.RcpnoList)
                .HasMaxLength(100)
                .HasColumnName("rcpno_list");
            entity.Property(e => e.RcptMoney)
                .HasColumnType("double(15,3)")
                .HasColumnName("rcpt_money");
            entity.Property(e => e.RemainMoney)
                .HasColumnType("double(15,3)")
                .HasColumnName("remain_money");
            entity.Property(e => e.RxLicenseNo)
                .HasMaxLength(15)
                .HasColumnName("rx_license_no");
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("sex");
            entity.Property(e => e.Spclty)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("spclty");
            entity.Property(e => e.UcMoney)
                .HasColumnType("double(15,3)")
                .HasColumnName("uc_money");
            entity.Property(e => e.VnGuid)
                .HasMaxLength(38)
                .HasColumnName("vn_guid");
            entity.Property(e => e.Vstdate).HasColumnName("vstdate");
            entity.Property(e => e.XrayPaidOk)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("xray_paid_ok");
            entity.Property(e => e.Ym)
                .HasMaxLength(7)
                .HasColumnName("ym");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
