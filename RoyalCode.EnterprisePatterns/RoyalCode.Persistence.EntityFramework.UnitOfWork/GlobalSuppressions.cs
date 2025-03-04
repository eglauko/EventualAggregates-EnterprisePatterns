﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", 
    Justification = "Using EF interceptors.", 
    Scope = "member", 
    Target = "~M:RoyalCode.Persistence.EntityFramework.UnitOfWork.UnitOfWork`1.#ctor(`0)")]
