﻿namespace _04_Glory
{
    public class Order
    {
        public int Id { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Created,
        Accepted,
        InProgress,
        Done
    }

    public class Document
    {

    }    
}