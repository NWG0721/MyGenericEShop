namespace MyGenericEShop.Core.Common.Results
{
	/// <summary>
	/// Enumeration for standardized operation result codes.
	/// </summary>
	public enum OperationCode
	{
		// General
		UnknownError = -1,
		Canceled = -2,

		// Select
		SelectSuccess = 1000,
		SelectFailed = 1100,
		SelectNullResult = 1010,

		SelectManySuccess = 1001,
		SelectManyFailed = 1101,
		SelectManyNullResult = 1011,

		SelectDeletedSuccess = 1003,
		SelectDeletedFailed = 1103,
		SelectDeletedNullResult = 1013,

		// Insert
		InsertSuccess = 3000,
		InsertFailed = 3100,
		InsertNullArgument = 3020,

		InsertManySuccess = 3001,
		InsertManyFailed = 3101,
		InsertManyNullArgument = 3021,

		// Update
		UpdateSuccess = 5000,
		UpdateFailed = 5100,
		UpdateNullArgument = 5020,

		// Delete
		HardDeleteSuccess = 7000,
		HardDeleteFailed = 7100,
		HardDeleteNullArgument = 7020,

		HardDeleteManySuccess = 7001,
		HardDeleteManyFailed = 7101,
		HardDeleteManyNullArgument = 7021,

		SoftDeleteSuccess = 7002,
		SoftDeleteFailed = 7102,
		SoftDeleteNullArgument = 7022,

		DeleteFailed = 7103,

		// Restore
		RestoreSuccess = 9000,
		RestoreFailed = 9100,
		RestoreNullArgument = 9020,

		RestoreManySuccess = 9001,
		RestoreManyFailed = 9101,
		RestoreManyNullArgument = 9021
	}
}


/*

 -1 => error code
 -2 => Canceled

 x1xx => operation failed
 x0xx => operation success
 xx1x => returning null
 xx2x => getting null argument
 xx0x => returning data

select => 1xxx
insert => 3xxx
update => 5xxx
delete => 7xxx
restore => 9xxx
 ---
select operation codes=> 
	return one : 1xx0
		return success : 1000
		return failed : 1100
		return null : 1010
	return many : 1xx1
		return success : 1001
		return failed : 1101
		return null : 1011
	return deleted : 1xx3
		return success : 1003
		return failed : 1103
		return null : 1013

insert operation codes=>
	insert one : 3xx0
		return success : 3000
		return failed : 3100
		null argument : 3020
	insert many : 3xx1
		return success : 3001
		return failed : 3101
		null argument : 3021

update operation codes=>
	return success : 5000
	return failed : 5100
	null argument : 5020

delete operation codes=>
	hard delete one => 7xx0
		return success : 7000
		return failed : 7100
		null argument : 7020
	hard delete many => 7xx1
		return success : 7001
		return failed : 7101
		null argument : 7021
	soft delete one => 7xx2
		return success : 7002
		return failed : 7102
		null argument : 7022
	soft delete one => 7xx3
		return success : 7003
		return failed : 7103
		null argument : 7023

restore operation codes=>
	restore one => 9xx0
		return success : 9000
		return failed : 9100
		null argument : 9020
	restore many => 9xx1
		return success : 9001
		return failed : 9101
		null argument : 9021

 */