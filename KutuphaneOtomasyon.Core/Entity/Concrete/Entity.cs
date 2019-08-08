using System;
using KutuphaneOtomasyon.Core.Entity.Abstract;

namespace KutuphaneOtomasyon.Core.Entity.Concrete
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        
        public bool Silindi { get; set; }
    }
}