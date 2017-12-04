using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Open.Social.Core.Model.Enum.Finance
{
    public enum TransactionType : int
    {
        /// <summary>Grant Credit Transaction</summary>
        [Description("Debit Transaction")]
        DBT = 1,
        /// <summary>Credit Debit Transaction</summary>
        [Description("Credit Transaction")]
        CDT = 2,
        /// <summary>Credit Reversal Transaction</summary>
        [Description("Credit Reversal Transaction")]
        CRT = 3,
        /// <summary>Credit Unlock Transaction (Sender Account)</summary>
        [Description("Credit Unlock Transaction (Sender Account)")]
        CUTSA = 4,
        /// <summary>Credit Unlock Transaction (Receiver Account)</summary>
        [Description("Credit Unlock Transaction (Receiver Account)")]
        CUTRA = 5,
        /// <summary>Credit Lock Transaction (Sender Account)</summary>
        [Description("Credit Lock Transaction (Sender Account)")]
        CLTSA = 6,
        /// <summary>Credit Lock Transaction (Receiver Account)</summary>
        [Description("Credit Lock Transaction (Receiver Account)")]
        CLTRA = 7,
        /// <summary>Credit Expiration Transaction</summary>
        [Description("Credit Expiration Transaction")]
        CET = 8,
        /// <summary>Sender Credit Transfer Transaction</summary>
        [Description("Sender Credit Transfer Transaction")]
        SCTT = 9,
        /// <summary>Receiver Credit Transfer Transaction</summary>
        [Description("Receiver Credit Transfer Transaction")]
        RCTT = 10,
        /// <summary>Redeem Transaction</summary>
        [Description("Redeem Transaction")]
        RT = 11,
        /// <summary>Debit Reversal Transaction</summary>
        [Description("Debit Reversal Transaction")]
        DRT = 12,
        /// <summary>POS Redeem Credit Transaction</summary>
        [Description("POS Redeem Credit Transaction")]
        POSRCT = 13,
        /// <summary>POS Redeem Debit Transaction</summary>
        [Description("POS Redeem Debit Transaction")]
        POSRDT = 14,
        /// <summary>Voucher's Validation Credit Transaction</summary>
        [Description("Voucher's Validation Credit Transaction")]
        VVCT = 15,
        /// <summary>Voucher's Validation Debit Transaction</summary>
        [Description("Voucher's Validation Debit Transaction")]
        VVDT = 16,
        /// <summary>Expired Balance's Debit Transaction</summary>
        [Description("Expired Balance's Debit Transaction")]
        EBDT = 17,
        /// <summary>Expired Balance's Credit Transaction</summary>
        [Description("Expired Balance's Credit Transaction")]
        EBCT = 18,
        /// <summary>Overdrawn Debit Transaction</summary>
        [Description("Overdrawn Debit Transaction")]
        ODT = 19

    }
}
