﻿namespace ClassesKey.Teclado
{
    public abstract class Tecla
    {
        // Representa o código da tecla precionada
        public abstract string codigo { get;}
        public abstract string nome { get; }

        // Este método pode ser sobrescrevido caso
        // a tecla precise executar algum procedimento
        // junto ao Retorno
        public virtual string GetTecla()
        {
            return nome;
        }
    }
}
