namespace Anfx.Domain.Entities;

public partial class PSV_Contrato
{
    public PSV_Contrato()
    {
        this.PSV_ContratoPagoIrregular = new HashSet<PSV_ContratoPagoIrregular>();
        this.PSV_Movimiento = new HashSet<PSV_Movimiento>();
        this.PSV_RelActivoPasivo = new HashSet<PSV_RelActivoPasivo>();
        this.PSV_LineaCredito = new HashSet<PSV_LineaCredito>();
        this.PSV_TablaAmortiza = new HashSet<PSV_TablaAmortiza>();
        this.PSV_Terminacion = new HashSet<PSV_Terminacion>();
    }

    public int IdContrato { get; set; }
    public string Contrato { get; set; }
    public Nullable<int> IdTipoCredito { get; set; }
    public Nullable<int> IdEstatusContrato { get; set; }
    public Nullable<decimal> Capital { get; set; }
    public Nullable<decimal> PorcEnganche { get; set; }
    public Nullable<decimal> Enganche { get; set; }
    public Nullable<decimal> CapitalFinanciado { get; set; }
    public int IdPeriodicidad { get; set; }
    public Nullable<int> Plazo { get; set; }
    public int IdMoneda { get; set; }
    public Nullable<System.DateTime> FecInicioContrato { get; set; }
    public Nullable<System.DateTime> FecPrimeraRenta { get; set; }
    public Nullable<System.DateTime> FecActivacion { get; set; }
    public Nullable<System.DateTime> FecFinContrato { get; set; }
    public int IdTasa { get; set; }
    public Nullable<decimal> TasaBase { get; set; }
    public Nullable<decimal> PuntosMas { get; set; }
    public Nullable<decimal> PuntosPor { get; set; }
    public Nullable<decimal> Tasa { get; set; }
    public Nullable<decimal> TasaBaseMora { get; set; }
    public int IdTasaMora { get; set; }
    public Nullable<decimal> PuntosMasMora { get; set; }
    public Nullable<decimal> PuntosPorMora { get; set; }
    public Nullable<decimal> FactorMora { get; set; }
    public Nullable<decimal> TasaMora { get; set; }
    public Nullable<decimal> SaldoInsoluto { get; set; }
    public Nullable<decimal> BallonPayment { get; set; }
    public Nullable<decimal> PorcBallonPayment { get; set; }
    public Nullable<decimal> ValorResidual { get; set; }
    public Nullable<decimal> PorcValorResidual { get; set; }
    public Nullable<decimal> DepositoEnGarantia { get; set; }
    public Nullable<decimal> OpcionDeCompra { get; set; }
    public Nullable<decimal> PorcOpcionDeCompra { get; set; }
    public Nullable<decimal> TasaIva { get; set; }
    public Nullable<int> VersionTabla { get; set; }
    public Nullable<int> IdTipoCalculoTasaVariable { get; set; }
    public Nullable<decimal> NroRentasDepositoGarantia { get; set; }
    public Nullable<System.DateTime> FechaFirmaContrato { get; set; }
    public Nullable<int> IdTipoMantenimiento { get; set; }
    public Nullable<decimal> TasaMensual { get; set; }
    public Nullable<System.DateTime> FechaCierre { get; set; }
    public Nullable<bool> TasaEsVariable { get; set; }
    public int IdFondeador { get; set; }
    public Nullable<decimal> FactorFIRA { get; set; }
    public int IdTipoTablaAmortiza { get; set; }
    public Nullable<int> IdPeriodicidad_TTA { get; set; }
    public Nullable<int> IdTipoPagoCapital { get; set; }
    public Nullable<int> NoPagosIrregulares { get; set; }
    public Nullable<int> IdTipoCapitalizacion { get; set; }
    public bool CapturaManualTAPasiva { get; set; }

    public virtual PSV_EstatusContrato PSV_EstatusContrato { get; set; }
    public virtual PSV_Fondeador PSV_Fondeador { get; set; }
    public virtual PSV_TipoCapitalizacion PSV_TipoCapitalizacion { get; set; }
    public virtual PSV_TipoCredito PSV_TipoCredito { get; set; }
    public virtual PSV_TipoPagoCapital PSV_TipoPagoCapital { get; set; }
    public virtual SB_Periodicidad SB_Periodicidad { get; set; }
    public virtual SB_Periodicidad SB_Periodicidad1 { get; set; }
    public virtual SB_TipoMoneda SB_TipoMoneda { get; set; }
    public virtual Tasa Tasa1 { get; set; }
    public virtual Tasa Tasa2 { get; set; }
    public virtual ICollection<PSV_ContratoPagoIrregular> PSV_ContratoPagoIrregular { get; set; }
    public virtual ICollection<PSV_Movimiento> PSV_Movimiento { get; set; }
    public virtual ICollection<PSV_RelActivoPasivo> PSV_RelActivoPasivo { get; set; }
    public virtual ICollection<PSV_LineaCredito> PSV_LineaCredito { get; set; }
    public virtual PSV_TipoTablaAmortiza PSV_TipoTablaAmortiza { get; set; }
    public virtual ICollection<PSV_TablaAmortiza> PSV_TablaAmortiza { get; set; }
    public virtual ICollection<PSV_Terminacion> PSV_Terminacion { get; set; }
}