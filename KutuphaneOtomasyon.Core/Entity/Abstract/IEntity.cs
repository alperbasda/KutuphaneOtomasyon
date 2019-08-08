using System;

namespace KutuphaneOtomasyon.Core.Entity.Abstract
{
    public interface IEntity
    {
        int Id { get; set; }

        bool Silindi { get; set; }
    }
}