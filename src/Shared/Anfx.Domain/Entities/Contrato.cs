//namespace Anfx.Domain.Entities;

//public class Contrato
//{
//    public Contrato()
//    {
//        this.PSV_RelActivoPasivo = new HashSet<PSV_RelActivoPasivo>();
//    }

//    public int IdContrato { get; set; }
//    public string Contrato1 { get; set; }
//    public Nullable<int> IdPersona { get; set; }
//    public Nullable<int> IdTipoCredito { get; set; }
//    public Nullable<int> IdEstatusContrato { get; set; }
//    public Nullable<decimal> Capital { get; set; }
//    public Nullable<decimal> PorcEnganche { get; set; }
//    public Nullable<decimal> Enganche { get; set; }
//    public Nullable<decimal> CapitalFinanciado { get; set; }
//    public int IdPeriodicidad { get; set; }
//    public Nullable<int> Plazo { get; set; }
//    public int IdMoneda { get; set; }
//    public Nullable<System.DateTime> FecInicioContrato { get; set; }
//    public Nullable<System.DateTime> FecPrimeraRenta { get; set; }
//    public Nullable<System.DateTime> FecActivacion { get; set; }
//    public Nullable<System.DateTime> FecFinContrato { get; set; }
//    public int IdTasa { get; set; }
//    public Nullable<decimal> TasaBase { get; set; }
//    public Nullable<decimal> PuntosMas { get; set; }
//    public Nullable<decimal> PuntosPor { get; set; }
//    public Nullable<decimal> Tasa { get; set; }
//    public Nullable<decimal> TasaBaseMora { get; set; }
//    public int IdTasaMora { get; set; }
//    public Nullable<decimal> PuntosMasMora { get; set; }
//    public Nullable<decimal> PuntosPorMora { get; set; }
//    public Nullable<decimal> FactorMora { get; set; }
//    public Nullable<decimal> TasaMora { get; set; }
//    public Nullable<decimal> SaldoInsoluto { get; set; }
//    public Nullable<decimal> BallonPayment { get; set; }
//    public Nullable<decimal> PorcBallonPayment { get; set; }
//    public Nullable<decimal> ValorResidual { get; set; }
//    public Nullable<decimal> PorcValorResidual { get; set; }
//    public Nullable<decimal> DepositoEnGarantia { get; set; }
//    public Nullable<decimal> OpcionDeCompra { get; set; }
//    public Nullable<decimal> PorcOpcionDeCompra { get; set; }
//    public Nullable<decimal> TasaIva { get; set; }
//    public Nullable<int> VersionTabla { get; set; }
//    public Nullable<int> IdTipoCalculoTasaVariable { get; set; }
//    public Nullable<decimal> NroRentasDepositoGarantia { get; set; }
//    public Nullable<System.DateTime> FechaFirmaContrato { get; set; }
//    public Nullable<int> IdTipoMantenimiento { get; set; }
//    public Nullable<decimal> TasaMensual { get; set; }
//    public Nullable<int> IdUsuario { get; set; }
//    public Nullable<int> IdSucursal { get; set; }
//    public Nullable<int> IdReestructura { get; set; }
//    public Nullable<int> IdSector { get; set; }
//    public Nullable<int> IdSubSector { get; set; }
//    public Nullable<bool> EsWriteOff { get; set; }
//    public Nullable<System.DateTime> FechaCierre { get; set; }
//    public Nullable<int> IdCotizador { get; set; }
//    public Nullable<bool> TasaEsVariable { get; set; }
//    public string GraciaCapital { get; set; }
//    public string GraciaInteres { get; set; }
//    public Nullable<decimal> FactorFIRA { get; set; }
//    public Nullable<int> IdCredito { get; set; }
//    public Nullable<int> NumeroPagosCapital { get; set; }
//    public Nullable<int> IdTipoTablaAmortiza { get; set; }
//    public Nullable<int> IdPeriodicidad_TTA { get; set; }
//    public Nullable<int> IdTipoPagoCapital { get; set; }
//    public Nullable<int> NoPagosIrregulares { get; set; }
//    public Nullable<int> IdTipoCapitalizacion { get; set; }
//    public bool Emproblemado { get; set; }
//    public string InversionPrincipal { get; set; }
//    public int IdPeriodicidadTC { get; set; }
//    public bool CapturaManualTAPasiva { get; set; }

//    public virtual EstatusContrato EstatusContrato { get; set; }
//    public virtual SB_Periodicidad SB_Periodicidad { get; set; }
//    public virtual SB_TipoMoneda SB_TipoMoneda { get; set; }
//    public virtual Tasa Tasa1 { get; set; }
//    public virtual Tasa Tasa2 { get; set; }
//    public virtual TipoCalculoTasaVariable TipoCalculoTasaVariable { get; set; }
//    public virtual TipoMantenimiento TipoMantenimiento { get; set; }
//    public virtual ICollection<PSV_RelActivoPasivo> PSV_RelActivoPasivo { get; set; }
//    public virtual TipoCredito TipoCredito { get; set; }
//    public virtual PSV_TipoCapitalizacion PSV_TipoCapitalizacion { get; set; }
//    public virtual PSV_TipoPagoCapital PSV_TipoPagoCapital { get; set; }
//    public virtual PSV_TipoTablaAmortiza PSV_TipoTablaAmortiza { get; set; }
//    public virtual SB_Periodicidad SB_Periodicidad1 { get; set; }
//    public virtual SB_Periodicidad SB_Periodicidad2 { get; set; }
//}


//public partial class EstatusContrato
//{
//    public EstatusContrato()
//    {
//        this.Contrato = new HashSet<Contrato>();
//    }

//    public int IdEstatusContrato { get; set; }
//    public string EstatusContrato1 { get; set; }

//    public virtual ICollection<Contrato> Contrato { get; set; }
//}



//public partial class SB_Periodicidad
//{
//    public SB_Periodicidad()
//    {
//        this.Contrato = new HashSet<Contrato>();
//        this.PSV_TipoTablaAmortizaPeriodicidad = new HashSet<PSV_TipoTablaAmortizaPeriodicidad>();
//        this.PSV_Contrato = new HashSet<PSV_Contrato>();
//        this.PSV_Contrato1 = new HashSet<PSV_Contrato>();
//        this.Contrato1 = new HashSet<Contrato>();
//        this.Contrato2 = new HashSet<Contrato>();
//    }

//    public int IdPeriodicidad { get; set; }
//    public string CveCortaPeriodicidad { get; set; }
//    public string DescPeriodicidad { get; set; }
//    public Nullable<int> ParamDias { get; set; }
//    public Nullable<int> ParamMes { get; set; }
//    public bool sDefault { get; set; }
//    public bool Band { get; set; }
//    public Nullable<bool> PedirDiasVencimiento { get; set; }
//    public Nullable<int> CantidadDiasVencimiento { get; set; }
//    public Nullable<bool> Activo { get; set; }
//    public Nullable<int> NoPagosMes { get; set; }
//    public decimal NroPagosAnio { get; set; }

//    public virtual ICollection<Contrato> Contrato { get; set; }
//    public virtual ICollection<PSV_TipoTablaAmortizaPeriodicidad> PSV_TipoTablaAmortizaPeriodicidad { get; set; }
//    public virtual ICollection<PSV_Contrato> PSV_Contrato { get; set; }
//    public virtual ICollection<PSV_Contrato> PSV_Contrato1 { get; set; }
//    public virtual ICollection<Contrato> Contrato1 { get; set; }
//    public virtual ICollection<Contrato> Contrato2 { get; set; }
//}


//public partial class SB_TipoMoneda
//{
//    public SB_TipoMoneda()
//    {
//        this.Contrato = new HashSet<Contrato>();
//        this.PSV_LineaCredito = new HashSet<PSV_LineaCredito>();
//        this.PSV_Contrato = new HashSet<PSV_Contrato>();
//    }

//    public int IdTipoMoneda { get; set; }
//    public string DescTipoMoneda { get; set; }
//    public string CveCortaTipoMoneda { get; set; }
//    public bool sDefault { get; set; }
//    public Nullable<decimal> MontoConvercion { get; set; }

//    public virtual ICollection<Contrato> Contrato { get; set; }
//    public virtual ICollection<PSV_LineaCredito> PSV_LineaCredito { get; set; }
//    public virtual ICollection<PSV_Contrato> PSV_Contrato { get; set; }
//}


//public partial class PSV_Contrato
//{
//    public PSV_Contrato()
//    {
//        this.PSV_ContratoPagoIrregular = new HashSet<PSV_ContratoPagoIrregular>();
//        this.PSV_Movimiento = new HashSet<PSV_Movimiento>();
//        this.PSV_RelActivoPasivo = new HashSet<PSV_RelActivoPasivo>();
//        this.PSV_LineaCredito = new HashSet<PSV_LineaCredito>();
//        this.PSV_TablaAmortiza = new HashSet<PSV_TablaAmortiza>();
//        this.PSV_Terminacion = new HashSet<PSV_Terminacion>();
//    }

//    public int IdContrato { get; set; }
//    public string Contrato { get; set; }
//    public Nullable<int> IdTipoCredito { get; set; }
//    public Nullable<int> IdEstatusContrato { get; set; }
//    public Nullable<decimal> Capital { get; set; }
//    public Nullable<decimal> PorcEnganche { get; set; }
//    public Nullable<decimal> Enganche { get; set; }
//    public Nullable<decimal> CapitalFinanciado { get; set; }
//    public int IdPeriodicidad { get; set; }
//    public Nullable<int> Plazo { get; set; }
//    public int IdMoneda { get; set; }
//    public Nullable<System.DateTime> FecInicioContrato { get; set; }
//    public Nullable<System.DateTime> FecPrimeraRenta { get; set; }
//    public Nullable<System.DateTime> FecActivacion { get; set; }
//    public Nullable<System.DateTime> FecFinContrato { get; set; }
//    public int IdTasa { get; set; }
//    public Nullable<decimal> TasaBase { get; set; }
//    public Nullable<decimal> PuntosMas { get; set; }
//    public Nullable<decimal> PuntosPor { get; set; }
//    public Nullable<decimal> Tasa { get; set; }
//    public Nullable<decimal> TasaBaseMora { get; set; }
//    public int IdTasaMora { get; set; }
//    public Nullable<decimal> PuntosMasMora { get; set; }
//    public Nullable<decimal> PuntosPorMora { get; set; }
//    public Nullable<decimal> FactorMora { get; set; }
//    public Nullable<decimal> TasaMora { get; set; }
//    public Nullable<decimal> SaldoInsoluto { get; set; }
//    public Nullable<decimal> BallonPayment { get; set; }
//    public Nullable<decimal> PorcBallonPayment { get; set; }
//    public Nullable<decimal> ValorResidual { get; set; }
//    public Nullable<decimal> PorcValorResidual { get; set; }
//    public Nullable<decimal> DepositoEnGarantia { get; set; }
//    public Nullable<decimal> OpcionDeCompra { get; set; }
//    public Nullable<decimal> PorcOpcionDeCompra { get; set; }
//    public Nullable<decimal> TasaIva { get; set; }
//    public Nullable<int> VersionTabla { get; set; }
//    public Nullable<int> IdTipoCalculoTasaVariable { get; set; }
//    public Nullable<decimal> NroRentasDepositoGarantia { get; set; }
//    public Nullable<System.DateTime> FechaFirmaContrato { get; set; }
//    public Nullable<int> IdTipoMantenimiento { get; set; }
//    public Nullable<decimal> TasaMensual { get; set; }
//    public Nullable<System.DateTime> FechaCierre { get; set; }
//    public Nullable<bool> TasaEsVariable { get; set; }
//    public int IdFondeador { get; set; }
//    public Nullable<decimal> FactorFIRA { get; set; }
//    public int IdTipoTablaAmortiza { get; set; }
//    public Nullable<int> IdPeriodicidad_TTA { get; set; }
//    public Nullable<int> IdTipoPagoCapital { get; set; }
//    public Nullable<int> NoPagosIrregulares { get; set; }
//    public Nullable<int> IdTipoCapitalizacion { get; set; }
//    public Nullable<System.Guid> IdFileName { get; set; }
//    public bool CapturaManualTAPasiva { get; set; }

//    public virtual PSV_EstatusContrato PSV_EstatusContrato { get; set; }
//    public virtual PSV_Fondeador PSV_Fondeador { get; set; }
//    public virtual PSV_TipoCapitalizacion PSV_TipoCapitalizacion { get; set; }
//    public virtual PSV_TipoCredito PSV_TipoCredito { get; set; }
//    public virtual PSV_TipoPagoCapital PSV_TipoPagoCapital { get; set; }
//    public virtual SB_Periodicidad SB_Periodicidad { get; set; }
//    public virtual SB_Periodicidad SB_Periodicidad1 { get; set; }
//    public virtual SB_TipoMoneda SB_TipoMoneda { get; set; }
//    public virtual Tasa Tasa1 { get; set; }
//    public virtual Tasa Tasa2 { get; set; }
//    public virtual ICollection<PSV_ContratoPagoIrregular> PSV_ContratoPagoIrregular { get; set; }
//    public virtual ICollection<PSV_Movimiento> PSV_Movimiento { get; set; }
//    public virtual ICollection<PSV_RelActivoPasivo> PSV_RelActivoPasivo { get; set; }
//    public virtual ICollection<PSV_LineaCredito> PSV_LineaCredito { get; set; }
//    public virtual PSV_TipoTablaAmortiza PSV_TipoTablaAmortiza { get; set; }
//    public virtual ICollection<PSV_TablaAmortiza> PSV_TablaAmortiza { get; set; }
//    public virtual ICollection<PSV_Terminacion> PSV_Terminacion { get; set; }
//}



//public partial class PSV_ContratoPagoIrregular
//{
//    public int NoPago { get; set; }
//    public int IdContrato { get; set; }
//    public decimal Capital { get; set; }
//    public System.DateTime FecVencimiento { get; set; }
//    public int VersionTabla { get; set; }
//    public bool NoAplicaCapital { get; set; }
//    public bool Procesado { get; set; }

//    public virtual PSV_Contrato PSV_Contrato { get; set; }
//}


//lic partial class Tasa
//{
//    public Tasa()
//    {
//        this.Contrato = new HashSet<Contrato>();
//        this.Contrato1 = new HashSet<Contrato>();
//        this.PSV_LineaCredito = new HashSet<PSV_LineaCredito>();
//        this.PSV_Contrato = new HashSet<PSV_Contrato>();
//        this.PSV_Contrato1 = new HashSet<PSV_Contrato>();
//    }

//    public int IdTasa { get; set; }
//    public string Tasa1 { get; set; }
//    public Nullable<decimal> ValorTasa { get; set; }
//    public Nullable<System.DateTime> FecTasa { get; set; }
//    public Nullable<bool> EsVariable { get; set; }
//    public Nullable<int> IdFondeador { get; set; }
//    public Nullable<decimal> Spred { get; set; }
//    public Nullable<decimal> RangoMinimo { get; set; }
//    public Nullable<decimal> RangoMaximo { get; set; }
//    public Nullable<int> IdTipoCredito { get; set; }
//    public Nullable<int> IdPlazo { get; set; }
//    public Nullable<decimal> Valor { get; set; }
//    public Nullable<decimal> PuntosAdicionales { get; set; }

//    public virtual ICollection<Contrato> Contrato { get; set; }
//    public virtual ICollection<Contrato> Contrato1 { get; set; }
//    public virtual TipoCredito TipoCredito { get; set; }
//    public virtual ICollection<PSV_LineaCredito> PSV_LineaCredito { get; set; }
//    public virtual ICollection<PSV_Contrato> PSV_Contrato { get; set; }
//    public virtual ICollection<PSV_Contrato> PSV_Contrato1 { get; set; }
//}


//public partial class TipoCredito
//{
//    public TipoCredito()
//    {
//        this.Contrato = new HashSet<Contrato>();
//        this.Tasa = new HashSet<Tasa>();
//        this.PSV_RelLineaCreditoTipoCredito = new HashSet<PSV_RelLineaCreditoTipoCredito>();
//    }

//    public int IdTipoCredito { get; set; }
//    public string ClaveTipoCredito { get; set; }
//    public string TipoCredito1 { get; set; }
//    public Nullable<int> IdTipoMovimiento { get; set; }
//    public Nullable<bool> PermiteEnganche { get; set; }
//    public Nullable<bool> CausaPenaPrepago { get; set; }
//    public Nullable<bool> PermiteBallonPayment { get; set; }
//    public Nullable<bool> ManejaActivos { get; set; }
//    public Nullable<bool> PermiteDepositoEnGarantia { get; set; }
//    public Nullable<bool> PermiteOpcionDeCompra { get; set; }
//    public Nullable<bool> ActivosConIvaSumanCapital { get; set; }
//    public Nullable<bool> CalculaIvaTasaReal { get; set; }
//    public Nullable<bool> PermiteValorResidual { get; set; }
//    public string Prefijo { get; set; }
//    public string Postfijo { get; set; }
//    public Nullable<int> Consecutivo { get; set; }
//    public Nullable<int> IdTipoMovimientoEnganche { get; set; }
//    public Nullable<int> IdTipoMovimientoBallon { get; set; }
//    public Nullable<int> IdTipoMovimientoValorResidual { get; set; }
//    public Nullable<int> IdTipoMovimientoDeposito { get; set; }
//    public Nullable<int> IdTipoMovimientoOpcion { get; set; }
//    public Nullable<int> IdEmpresa { get; set; }
//    public int EsquemaFinanciero { get; set; }
//    public Nullable<decimal> TasaMoraDefault { get; set; }
//    public Nullable<int> IdTipoMovimientoMora { get; set; }
//    public Nullable<int> IdTipoMovimientoGastos { get; set; }
//    public Nullable<decimal> FactorGastoCob { get; set; }
//    public Nullable<decimal> MaxMontoGastoCob { get; set; }
//    public Nullable<int> PeriodoGracia { get; set; }
//    public Nullable<int> IdTipoMovimientoCancelCheque { get; set; }
//    public Nullable<decimal> PorcCancelacionCheque { get; set; }
//    public Nullable<decimal> MontoPenaNoDevuelto { get; set; }
//    public Nullable<int> IdTipoMovimientoNoDevuelto { get; set; }
//    public Nullable<int> IdMonedaNoDevuelto { get; set; }
//    public Nullable<int> MesesDePenaNoDevuelto { get; set; }
//    public Nullable<decimal> MontoKilometraje { get; set; }
//    public Nullable<int> IdTipoMonedaKm { get; set; }
//    public Nullable<decimal> CargoCheque { get; set; }
//    public Nullable<bool> AplicaGraciaCapital { get; set; }
//    public Nullable<int> GraciaCapital { get; set; }
//    public Nullable<decimal> CATMinimo { get; set; }
//    public Nullable<decimal> PorcComApertura { get; set; }
//    public Nullable<decimal> Gastoslegales { get; set; }
//    public Nullable<decimal> GastosdeRegistro { get; set; }
//    public Nullable<bool> PermiteSubsidio { get; set; }
//    public Nullable<bool> PermiteCreditoGrupal { get; set; }
//    public Nullable<int> IdTipoTablaAmortiza { get; set; }
//    public Nullable<bool> PermiteGastosAdministracion { get; set; }
//    public Nullable<int> IdTipoProducto { get; set; }
//    public Nullable<decimal> FactorTasaMora { get; set; }
//    public bool PermiteLimiteMontoCredito { get; set; }
//    public Nullable<decimal> MontoMinimo { get; set; }
//    public Nullable<decimal> MontoMaximo { get; set; }
//    public bool PermiteSeguroEnPeriodo { get; set; }
//    public Nullable<int> IdTipoMovimientoSeguro { get; set; }
//    public decimal PorcSeguroEnPeriodo { get; set; }
//    public bool PermiteAforo { get; set; }
//    public Nullable<decimal> PorcAforo { get; set; }
//    public bool PermiteGraciaCapitalInteres { get; set; }
//    public decimal FactorCapadicadDePago { get; set; }
//    public bool PermiteTasaVariable { get; set; }
//    public bool PermiteUsarPAyFactor { get; set; }
//    public bool SeUsaEnPasivos { get; set; }
//    public Nullable<bool> Estatus { get; set; }

//    public virtual ICollection<Contrato> Contrato { get; set; }
//    public virtual Empresa Empresa { get; set; }
//    public virtual ICollection<Tasa> Tasa { get; set; }
//    public virtual TipoMovimiento TipoMovimiento { get; set; }
//    public virtual TipoMovimiento TipoMovimiento1 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento2 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento3 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento4 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento5 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento6 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento7 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento8 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento9 { get; set; }
//    public virtual TipoMovimiento TipoMovimiento10 { get; set; }
//    public virtual ICollection<PSV_RelLineaCreditoTipoCredito> PSV_RelLineaCreditoTipoCredito { get; set; }
//}

//public partial class TipoMovimiento
//{
//    public TipoMovimiento()
//    {
//        this.PSV_Movimiento = new HashSet<PSV_Movimiento>();
//        this.TipoCredito = new HashSet<TipoCredito>();
//        this.TipoCredito1 = new HashSet<TipoCredito>();
//        this.TipoCredito2 = new HashSet<TipoCredito>();
//        this.TipoCredito3 = new HashSet<TipoCredito>();
//        this.TipoCredito4 = new HashSet<TipoCredito>();
//        this.TipoCredito5 = new HashSet<TipoCredito>();
//        this.TipoCredito6 = new HashSet<TipoCredito>();
//        this.TipoCredito7 = new HashSet<TipoCredito>();
//        this.TipoCredito8 = new HashSet<TipoCredito>();
//        this.TipoCredito9 = new HashSet<TipoCredito>();
//        this.TipoCredito10 = new HashSet<TipoCredito>();
//        this.PSV_TipoCredito = new HashSet<PSV_TipoCredito>();
//        this.PSV_TipoCredito1 = new HashSet<PSV_TipoCredito>();
//        this.PSV_TipoTerminacion = new HashSet<PSV_TipoTerminacion>();
//        this.PSV_TipoTerminacion1 = new HashSet<PSV_TipoTerminacion>();
//        this.PSV_TipoTerminacion2 = new HashSet<PSV_TipoTerminacion>();
//    }

//    public int IdTipoMovimiento { get; set; }
//    public string TipoMovimiento1 { get; set; }
//    public string ClaveTipoMovimiento { get; set; }
//    public Nullable<bool> GeneraIVACapital { get; set; }
//    public Nullable<bool> GeneraMora { get; set; }
//    public Nullable<bool> Capturable { get; set; }
//    public Nullable<bool> EsRenta { get; set; }
//    public Nullable<bool> Estatus { get; set; }
//    public Nullable<decimal> Orden { get; set; }
//    public Nullable<bool> GeneraIVAInteres { get; set; }
//    public Nullable<int> IdTipoGeneracionComprobante { get; set; }
//    public Nullable<bool> SeparaComprobante { get; set; }
//    public Nullable<bool> CalificaCarteraVencida { get; set; }
//    public Nullable<bool> GeneraCapital { get; set; }
//    public Nullable<bool> GeneraInteres { get; set; }
//    public Nullable<bool> GeneraFees { get; set; }

//    public virtual TipoGeneracionComprobante TipoGeneracionComprobante { get; set; }
//    public virtual ICollection<PSV_Movimiento> PSV_Movimiento { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito1 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito2 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito3 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito4 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito5 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito6 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito7 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito8 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito9 { get; set; }
//    public virtual ICollection<TipoCredito> TipoCredito10 { get; set; }
//    public virtual ICollection<PSV_TipoCredito> PSV_TipoCredito { get; set; }
//    public virtual ICollection<PSV_TipoCredito> PSV_TipoCredito1 { get; set; }
//    public virtual ICollection<PSV_TipoTerminacion> PSV_TipoTerminacion { get; set; }
//    public virtual ICollection<PSV_TipoTerminacion> PSV_TipoTerminacion1 { get; set; }
//    public virtual ICollection<PSV_TipoTerminacion> PSV_TipoTerminacion2 { get; set; }
//}