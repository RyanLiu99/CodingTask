using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RyanLiu.CodingTask.Web.Models
{

    public class SelectableEntity<T>
    {
        public T Entity { get; set; }
        public bool Selected { get; set; }

        public SelectableEntity()
        {
        }

        public SelectableEntity(T entity)
        {
            Entity = entity;
        }
    }
}