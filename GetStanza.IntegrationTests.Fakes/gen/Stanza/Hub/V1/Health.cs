// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: stanza/hub/v1/health.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Stanza.Hub.V1 {

  /// <summary>Holder for reflection information generated from stanza/hub/v1/health.proto</summary>
  public static partial class HealthReflection {

    #region Descriptor
    /// <summary>File descriptor for stanza/hub/v1/health.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static HealthReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChpzdGFuemEvaHViL3YxL2hlYWx0aC5wcm90bxINc3RhbnphLmh1Yi52MRoc",
            "Z29vZ2xlL2FwaS9hbm5vdGF0aW9ucy5wcm90bxoucHJvdG9jLWdlbi1vcGVu",
            "YXBpdjIvb3B0aW9ucy9hbm5vdGF0aW9ucy5wcm90bxoac3RhbnphL2h1Yi92",
            "MS9jb21tb24ucHJvdG8imQEKF1F1ZXJ5R3VhcmRIZWFsdGhSZXF1ZXN0Ej8K",
            "CHNlbGVjdG9yGAEgASgLMiMuc3RhbnphLmh1Yi52MS5HdWFyZEZlYXR1cmVT",
            "ZWxlY3RvclIIc2VsZWN0b3ISKgoOcHJpb3JpdHlfYm9vc3QYBCABKAVIAFIN",
            "cHJpb3JpdHlCb29zdIgBAUIRCg9fcHJpb3JpdHlfYm9vc3QiSQoYUXVlcnlH",
            "dWFyZEhlYWx0aFJlc3BvbnNlEi0KBmhlYWx0aBgBIAEoDjIVLnN0YW56YS5o",
            "dWIudjEuSGVhbHRoUgZoZWFsdGgyxgIKDUhlYWx0aFNlcnZpY2UStAIKEFF1",
            "ZXJ5R3VhcmRIZWFsdGgSJi5zdGFuemEuaHViLnYxLlF1ZXJ5R3VhcmRIZWFs",
            "dGhSZXF1ZXN0Gicuc3RhbnphLmh1Yi52MS5RdWVyeUd1YXJkSGVhbHRoUmVz",
            "cG9uc2UizgGSQa8BEhBHZXQgR3VhcmQgSGVhbHRoGmFVc2VkIGJ5IFNESyB0",
            "byBhbGxvdyBkZXZlbG9wZXJzIHRvIG1ha2UgZGVjaXNpb25zIGFib3V0IGdy",
            "YWNlZnVsIGRlZ3JhZGF0aW9uIG9mIGJhY2tlbmQgc2VydmljZXMuSjgKAzIw",
            "MBIxCgJPSxIrCikaJy5zdGFuemEuaHViLnYxLlF1ZXJ5R3VhcmRIZWFsdGhS",
            "ZXNwb25zZYLT5JMCFSIQL3YxL2hlYWx0aC9ndWFyZDoBKkKLAQoRY29tLnN0",
            "YW56YS5odWIudjFCC0hlYWx0aFByb3RvUAFaE3N0YW56YS9odWIvdjE7aHVi",
            "cGKiAgNTSFiqAg1TdGFuemEuSHViLlYxygINU3RhbnphXEh1YlxWMeICGVN0",
            "YW56YVxIdWJcVjFcR1BCTWV0YWRhdGHqAg9TdGFuemE6Okh1Yjo6VjFiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Api.AnnotationsReflection.Descriptor, global::Grpc.Gateway.ProtocGenOpenapiv2.Options.AnnotationsReflection.Descriptor, global::Stanza.Hub.V1.CommonReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Stanza.Hub.V1.QueryGuardHealthRequest), global::Stanza.Hub.V1.QueryGuardHealthRequest.Parser, new[]{ "Selector", "PriorityBoost" }, new[]{ "PriorityBoost" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Stanza.Hub.V1.QueryGuardHealthResponse), global::Stanza.Hub.V1.QueryGuardHealthResponse.Parser, new[]{ "Health" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Called by SDK to determine whether a Guard is overloaded at a given Feature's priority level. Used so that customer code can make good decisions about fail-fast or graceful degradation as high up the stack as possible. SDK may cache the result for up to 10 seconds.
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class QueryGuardHealthRequest : pb::IMessage<QueryGuardHealthRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<QueryGuardHealthRequest> _parser = new pb::MessageParser<QueryGuardHealthRequest>(() => new QueryGuardHealthRequest());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<QueryGuardHealthRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Stanza.Hub.V1.HealthReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QueryGuardHealthRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QueryGuardHealthRequest(QueryGuardHealthRequest other) : this() {
      _hasBits0 = other._hasBits0;
      selector_ = other.selector_ != null ? other.selector_.Clone() : null;
      priorityBoost_ = other.priorityBoost_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QueryGuardHealthRequest Clone() {
      return new QueryGuardHealthRequest(this);
    }

    /// <summary>Field number for the "selector" field.</summary>
    public const int SelectorFieldNumber = 1;
    private global::Stanza.Hub.V1.GuardFeatureSelector selector_;
    /// <summary>
    /// Only tags which are used for quota management should be included here - i.e. the list of quota_tags returned by the GetGuardConfig endpoint for this Guard. If tags are in use only one quota token will be issued at a time.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Stanza.Hub.V1.GuardFeatureSelector Selector {
      get { return selector_; }
      set {
        selector_ = value;
      }
    }

    /// <summary>Field number for the "priority_boost" field.</summary>
    public const int PriorityBoostFieldNumber = 4;
    private readonly static int PriorityBoostDefaultValue = 0;

    private int priorityBoost_;
    /// <summary>
    /// Used to boost priority - SDK can increase or decrease priority of request, relative to normal feature priority. For instance, a customer may wish to boost the priority of paid user traffic over free tier. Priority boosts may also be negative - for example, one might deprioritise bot traffic.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int PriorityBoost {
      get { if ((_hasBits0 & 1) != 0) { return priorityBoost_; } else { return PriorityBoostDefaultValue; } }
      set {
        _hasBits0 |= 1;
        priorityBoost_ = value;
      }
    }
    /// <summary>Gets whether the "priority_boost" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool HasPriorityBoost {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "priority_boost" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearPriorityBoost() {
      _hasBits0 &= ~1;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as QueryGuardHealthRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(QueryGuardHealthRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Selector, other.Selector)) return false;
      if (PriorityBoost != other.PriorityBoost) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (selector_ != null) hash ^= Selector.GetHashCode();
      if (HasPriorityBoost) hash ^= PriorityBoost.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (selector_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Selector);
      }
      if (HasPriorityBoost) {
        output.WriteRawTag(32);
        output.WriteInt32(PriorityBoost);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (selector_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Selector);
      }
      if (HasPriorityBoost) {
        output.WriteRawTag(32);
        output.WriteInt32(PriorityBoost);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (selector_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Selector);
      }
      if (HasPriorityBoost) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(PriorityBoost);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(QueryGuardHealthRequest other) {
      if (other == null) {
        return;
      }
      if (other.selector_ != null) {
        if (selector_ == null) {
          Selector = new global::Stanza.Hub.V1.GuardFeatureSelector();
        }
        Selector.MergeFrom(other.Selector);
      }
      if (other.HasPriorityBoost) {
        PriorityBoost = other.PriorityBoost;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (selector_ == null) {
              Selector = new global::Stanza.Hub.V1.GuardFeatureSelector();
            }
            input.ReadMessage(Selector);
            break;
          }
          case 32: {
            PriorityBoost = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            if (selector_ == null) {
              Selector = new global::Stanza.Hub.V1.GuardFeatureSelector();
            }
            input.ReadMessage(Selector);
            break;
          }
          case 32: {
            PriorityBoost = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class QueryGuardHealthResponse : pb::IMessage<QueryGuardHealthResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<QueryGuardHealthResponse> _parser = new pb::MessageParser<QueryGuardHealthResponse>(() => new QueryGuardHealthResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<QueryGuardHealthResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Stanza.Hub.V1.HealthReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QueryGuardHealthResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QueryGuardHealthResponse(QueryGuardHealthResponse other) : this() {
      health_ = other.health_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public QueryGuardHealthResponse Clone() {
      return new QueryGuardHealthResponse(this);
    }

    /// <summary>Field number for the "health" field.</summary>
    public const int HealthFieldNumber = 1;
    private global::Stanza.Hub.V1.Health health_ = global::Stanza.Hub.V1.Health.Unspecified;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::Stanza.Hub.V1.Health Health {
      get { return health_; }
      set {
        health_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as QueryGuardHealthResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(QueryGuardHealthResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Health != other.Health) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Health != global::Stanza.Hub.V1.Health.Unspecified) hash ^= Health.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Health != global::Stanza.Hub.V1.Health.Unspecified) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Health);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Health != global::Stanza.Hub.V1.Health.Unspecified) {
        output.WriteRawTag(8);
        output.WriteEnum((int) Health);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Health != global::Stanza.Hub.V1.Health.Unspecified) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Health);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(QueryGuardHealthResponse other) {
      if (other == null) {
        return;
      }
      if (other.Health != global::Stanza.Hub.V1.Health.Unspecified) {
        Health = other.Health;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Health = (global::Stanza.Hub.V1.Health) input.ReadEnum();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Health = (global::Stanza.Hub.V1.Health) input.ReadEnum();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code