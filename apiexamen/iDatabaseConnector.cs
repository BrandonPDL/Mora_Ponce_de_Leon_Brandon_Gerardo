namespace apiexamen
{
    public interface iDatabaseConnector
    {
        void EjecutarProcedimientoAlmacenado(string nombreProcedimiento, params object[] parametros);
    }
}
