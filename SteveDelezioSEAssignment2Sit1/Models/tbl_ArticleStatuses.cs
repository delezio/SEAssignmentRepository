
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace SteveDelezioSEAssignment2Sit1.Models
{

using System;
    using System.Collections.Generic;
    
public partial class tbl_ArticleStatuses
{

    public tbl_ArticleStatuses()
    {

        this.tbl_Articles = new HashSet<tbl_Articles>();

    }


    public int ArticleStatusId { get; set; }

    public string ArticleStatusName { get; set; }



    public virtual ICollection<tbl_Articles> tbl_Articles { get; set; }

}

}
