
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
    
public partial class tbl_StateWorkflows
{

    public int WorflowPositionId { get; set; }

    public int UserId { get; set; }

    public int StateId { get; set; }



    public virtual tbl_ArticleStates tbl_ArticleStates { get; set; }

    public virtual tbl_Users tbl_Users { get; set; }

}

}