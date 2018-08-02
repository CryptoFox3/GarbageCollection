CREATE TABLE [dbo].[Pickups] (
    [PickupId]    INT        IDENTITY (1, 1) NOT NULL,
    [PickupDate]  DATETIME   NOT NULL,
    [CustomerId]  INT        NOT NULL,
    [Zipcode]     INT        NOT NULL,
    [Repeat]      BIT        NOT NULL,
    [IsCompleted] BIT        NOT NULL,
    [PickupCost]  FLOAT (53) NOT NULL,
    CONSTRAINT [PK_dbo.Pickups] PRIMARY KEY CLUSTERED ([PickupId] ASC) 
);

