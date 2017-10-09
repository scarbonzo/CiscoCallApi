using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace calls.Models
{
    public partial class CallAnalyzerContext : DbContext
    {

        public virtual DbSet<TblCallsFull> TblCallsFull { get; set; }
        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCallsFull>(entity =>
            {
                entity.HasKey(e => e.CallId)
                    .HasName("PK__tblCalls__180B0E54014935CC");

                entity.ToTable("tblCallsFull");

                entity.HasIndex(e => new { e.OrigDeviceName, e.DestDeviceName, e.CallId })
                    .HasName("Index_Devices");

                entity.HasIndex(e => new { e.CallingPartyNumber, e.OriginalCalledPartyNumber, e.FinalCalledPartyNumber, e.CallId })
                    .HasName("Index_Numbers");

                entity.HasIndex(e => new { e.CallingPartyNumber, e.FinalCalledPartyNumber, e.DateTimeConnect, e.Duration, e.OrigDeviceName, e.DestDeviceName, e.OriginalCalledPartyNumber, e.DateTimeDisconnect })
                    .HasName("<Name of Missing Index, sysname,>");

                entity.HasIndex(e => new { e.DateTimeConnect, e.Duration, e.OrigDeviceName, e.DestDeviceName, e.CallingPartyNumber, e.OriginalCalledPartyNumber, e.FinalCalledPartyNumber, e.DateTimeDisconnect })
                    .HasName("ReportingEFIndex");

                entity.Property(e => e.CallId).HasColumnName("callID");

                entity.Property(e => e.AuthCodeDescription)
                    .HasColumnName("authCodeDescription")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AuthorizationCodeValue)
                    .HasColumnName("authorizationCodeValue")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AuthorizationLevel)
                    .HasColumnName("authorizationLevel")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CallSecuredStatus)
                    .HasColumnName("callSecuredStatus")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CallingPartyNumber)
                    .HasColumnName("callingPartyNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CallingPartyNumberPartition)
                    .HasColumnName("callingPartyNumberPartition")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CallingPartyUnicodeLoginUserId)
                    .HasColumnName("callingPartyUnicodeLoginUserID")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.CdrRecordType)
                    .HasColumnName("cdrRecordType")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ClientMatterCode)
                    .HasColumnName("clientMatterCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DateTimeConnect)
                    .HasColumnName("dateTimeConnect")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DateTimeDisconnect)
                    .HasColumnName("dateTimeDisconnect")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTimeOrigination)
                    .HasColumnName("dateTimeOrigination")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestCallTerminationOnBehalfOf)
                    .HasColumnName("destCallTerminationOnBehalfOf")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestCauseLocation)
                    .HasColumnName("destCause_location")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestCauseValue)
                    .HasColumnName("destCause_value")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestConversationId)
                    .HasColumnName("destConversationId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestDeviceName)
                    .HasColumnName("destDeviceName")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DestDtmfmethod)
                    .HasColumnName("destDTMFMethod")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestIpAddr)
                    .HasColumnName("destIpAddr")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestIpv4v6Addr)
                    .HasColumnName("destIpv4v6Addr")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DestLegIdentifier)
                    .HasColumnName("destLegIdentifier")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestMediaCapBandwidth)
                    .HasColumnName("destMediaCap_Bandwidth")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestMediaCapG723BitRate)
                    .HasColumnName("destMediaCap_g723BitRate")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestMediaCapMaxFramesPerPacket)
                    .HasColumnName("destMediaCap_maxFramesPerPacket")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestMediaCapPayloadCapability)
                    .HasColumnName("destMediaCap_payloadCapability")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestMediaTransportAddressIp)
                    .HasColumnName("destMediaTransportAddress_IP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestMediaTransportAddressPort)
                    .HasColumnName("destMediaTransportAddress_Port")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestNodeId)
                    .HasColumnName("destNodeId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestPrecedenceLevel)
                    .HasColumnName("destPrecedenceLevel")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestRsvpaudioStat)
                    .HasColumnName("destRSVPAudioStat")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DestRsvpvideoStat)
                    .HasColumnName("destRSVPVideoStat")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.DestSpan)
                    .HasColumnName("destSpan")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoCapBandwidth)
                    .HasColumnName("destVideoCap_Bandwidth")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoCapBandwidthChannel2)
                    .HasColumnName("destVideoCap_Bandwidth_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoCapCodec)
                    .HasColumnName("destVideoCap_Codec")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoCapCodecChannel2)
                    .HasColumnName("destVideoCap_Codec_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoCapResolution)
                    .HasColumnName("destVideoCap_Resolution")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoCapResolutionChannel2)
                    .HasColumnName("destVideoCap_Resolution_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoChannelRoleChannel2)
                    .HasColumnName("destVideoChannel_Role_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoTransportAddressIp)
                    .HasColumnName("destVideoTransportAddress_IP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoTransportAddressIpChannel2)
                    .HasColumnName("destVideoTransportAddress_IP_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoTransportAddressPort)
                    .HasColumnName("destVideoTransportAddress_Port")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DestVideoTransportAddressPortChannel2)
                    .HasColumnName("destVideoTransportAddress_Port_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FinalCalledPartyNumber)
                    .HasColumnName("finalCalledPartyNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FinalCalledPartyNumberPartition)
                    .HasColumnName("finalCalledPartyNumberPartition")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FinalCalledPartyUnicodeLoginUserId)
                    .HasColumnName("finalCalledPartyUnicodeLoginUserID")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.GlobalCallIdCallId)
                    .HasColumnName("globalCallID_callId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GlobalCallIdCallManagerId)
                    .HasColumnName("globalCallID_callManagerId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.GlobalCallIdClusterId)
                    .HasColumnName("globalCallId_ClusterID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.JoinOnBehalfOf)
                    .HasColumnName("joinOnBehalfOf")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastRedirectDn)
                    .HasColumnName("lastRedirectDn")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastRedirectDnPartition)
                    .HasColumnName("lastRedirectDnPartition")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastRedirectRedirectOnBehalfOf)
                    .HasColumnName("lastRedirectRedirectOnBehalfOf")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LastRedirectRedirectReason)
                    .HasColumnName("lastRedirectRedirectReason")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigCallTerminationOnBehalfOf)
                    .HasColumnName("origCallTerminationOnBehalfOf")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigCalledPartyRedirectOnBehalfOf)
                    .HasColumnName("origCalledPartyRedirectOnBehalfOf")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigCalledPartyRedirectReason)
                    .HasColumnName("origCalledPartyRedirectReason")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigCauseLocation)
                    .HasColumnName("origCause_location")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigCauseValue)
                    .HasColumnName("origCause_value")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigConversationId)
                    .HasColumnName("origConversationId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigDeviceName)
                    .HasColumnName("origDeviceName")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.OrigDtmfmethod)
                    .HasColumnName("origDTMFMethod")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigIpAddr)
                    .HasColumnName("origIpAddr")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigIpv4v6Addr)
                    .HasColumnName("origIpv4v6Addr")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.OrigLegCallIdentifier)
                    .HasColumnName("origLegCallIdentifier")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigMediaCapBandwidth)
                    .HasColumnName("origMediaCap_Bandwidth")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigMediaCapG723BitRate)
                    .HasColumnName("origMediaCap_g723BitRate")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigMediaCapMaxFramesPerPacket)
                    .HasColumnName("origMediaCap_maxFramesPerPacket")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigMediaCapPayloadCapability)
                    .HasColumnName("origMediaCap_payloadCapability")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigMediaTransportAddressIp)
                    .HasColumnName("origMediaTransportAddress_IP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigMediaTransportAddressPort)
                    .HasColumnName("origMediaTransportAddress_Port")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigNodeId)
                    .HasColumnName("origNodeId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigPrecedenceLevel)
                    .HasColumnName("origPrecedenceLevel")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigRsvpaudioStat)
                    .HasColumnName("origRSVPAudioStat")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.OrigRsvpvideoStat)
                    .HasColumnName("origRSVPVideoStat")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.OrigSpan)
                    .HasColumnName("origSpan")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoCapBandwidth)
                    .HasColumnName("origVideoCap_Bandwidth")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoCapBandwidthChannel2)
                    .HasColumnName("origVideoCap_Bandwidth_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoCapCodec)
                    .HasColumnName("origVideoCap_Codec")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoCapCodecChannel2)
                    .HasColumnName("origVideoCap_Codec_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoCapResolution)
                    .HasColumnName("origVideoCap_Resolution")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoCapResolutionChannel2)
                    .HasColumnName("origVideoCap_Resolution_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoChannelRoleChannel2)
                    .HasColumnName("origVideoChannel_Role_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoTransportAddressIp)
                    .HasColumnName("origVideoTransportAddress_IP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoTransportAddressIpChannel2)
                    .HasColumnName("origVideoTransportAddress_IP_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoTransportAddressPort)
                    .HasColumnName("origVideoTransportAddress_Port")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OrigVideoTransportAddressPortChannel2)
                    .HasColumnName("origVideoTransportAddress_Port_Channel2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OriginalCalledPartyNumber)
                    .HasColumnName("originalCalledPartyNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OriginalCalledPartyNumberPartition)
                    .HasColumnName("originalCalledPartyNumberPartition")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OutpulsedCalledPartyNumber)
                    .HasColumnName("outpulsedCalledPartyNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OutpulsedCallingPartyNumber)
                    .HasColumnName("outpulsedCallingPartyNumber")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Pkid).HasColumnName("pkid");
            });
        }
    }
}