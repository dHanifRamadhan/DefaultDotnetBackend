namespace DefaultDotnetBackend.Constants {
    public static class Messages {
        // TODO: Information
        public const string MAINTENANCE = "Maintenance";

        // TODO: Success
        public const string OK = "Successfully";

        // CRUD Opertaions
        public const string OK_CREATED = "Successfully created";
        public const string OK_UPDATED = "Successfully updated";
        public const string OK_DELETED = "Successfully deleted";
        public const string OK_RETRIEVED = "Successfully retrieved";
        public const string OK_RESTORED = "Successfully restored from archive";

        // File Operations
        public const string OK_UPLOADED = "File successfully uploaded";
        public const string OK_DOWNLOADED = "File successfully downloaded";
        public const string OK_IMPORTED = "File successfully imported";
        public const string OK_EXPORTED = "File successfully exported";
        public const string OK_BACKUP_CREATED = "System backup successfully created";

        // Authentication & User Management
        public const string OK_REGISTERED = "Successfully registered";
        public const string OK_LOGIN = "Authentication successful";
        public const string OK_LOGOUT = "Successfully logged out";
        public const string OK_PASSWORD_RESET = "Password successfully reset";
        public const string OK_PASSWORD_CHANGE = "Password successfully changed";
        public const string OK_EMAIL_CHANGE = "Email successfully changed";
        public const string OK_ACCOUNT_VERIFIED = "Account vetification successful";

        // System Operations
        public const string OK_MAINTENANCE_MODE = "Maintenance mode activated successfully";
        public const string OK_CONFIG_UPDATED = "Configuration successfully updated";

        // TODO: Warning
        public const string WARN = "Warning";

        // Data Warnings
        public const string WARN_BODY_REQURIED = "Request body required";
        public const string WARN_NOT_FOUND = "Data not found";
        public const string WARN_VALIDATION = "Validation failed";
        public const string WARN_PARTIAL_UPLOAD = "Partial upload completed with some failures";
        public const string WARN_IMPORT_INCOMPLETE = "Import completed with incomplete records";
        public const string WARN_DATA_STALE = "Displaying cached data - live data unavailable";
        public const string WARN_DUPLICATE = "Duplicate data detected";

        // File Warnings
        public const string WARN_FILE_TYPE_UNVERIFIED = "File type could not be verified";
        public const string WARN_LARGE_FILE = "File size exceeds recommended limits";
        public const string WARN_DUPLICATE_FILE = "Duplicate file detected in storage";

        // System Warnings
        public const string WARN_API_DEPRECATED = "API version is deprecated";
        public const string WARN_MAINTENANCE_SOON = "Planned maintenance in 15 minutes";
        public const string WARN_RESOURCE_INTENSIVE = "This operation may consume significant resources";

        // Security Warnings
        public const string WARN_PASSWORD_EXPIRING = "Password will expire in 3 days";
        public const string WARN_UNUSUAL_ACTIVITY = "Unusual account activity detected";
        public const string WARN_INSECURE_CONNECTION = "Connection is not using secure protocol";

        // TODO: Error
        public const string ERR = "Error";

        // Operational Errors
        public const string ERR_UPLOAD_FAILED = "File upload failed";
        public const string ERR_IMPORT_FORMAT = "Unsupported import file format";
        public const string ERR_EXPORT_LIMIT = "Export record limit exceeded";
        public const string ERR_PROCESSING_FILE = "Error processing uploaded file";
        
        // Validation Errors
        public const string ERR_UNAUTHORIZED = "Unauthorized access";
        public const string ERR_INVALID_CSV_FORMAT = "Malformed CSV structure detected";
        public const string ERR_MISSING_REQUIRED_FIELD = "Required field is missing";
        public const string ERR_DATE_RANGE_INVALID = "Invalid date range specified";
        
        // System Errors
        public const string ERR_DATABASE_CONNECTION = "Failed to connect to database";
        public const string ERR_QUEUE_OVERFLOW = "Processing queue capacity exceeded";
        public const string ERR_ENCRYPTION_FAILED = "Data encryption failed";
        public const string ERR_DECRYPTION_FAILED = "Data decryption failed";

        // Authentication Errors
        public const string ERR_INVALID_CREDENTIALS = "Invalid username or password";
        public const string ERR_2FA_FAILED = "Two-factor authentication failed";
        public const string ERR_SESSION_EXPIRED = "User session has expired";

        // TODO: Exception
        public const string EXCEPTION_INTERNALL_SERVER = "Internal server error";

        // Infrastructure Exceptions
        public const string EXCEPTION_EXTERNAL_SERVICE = "External service API failure";
        public const string EXCEPTION_SSL_HANDSHAKE = "SSL handshake failed";
        public const string EXCEPTION_MEMORY_LEAK = "Memory leak detected in service";
        
        // Data Exceptions
        public const string EXCEPTION_DATABASE_DEADLOCK = "Database deadlock occurred";
        public const string EXCEPTION_DATA_CORRUPTION = "Data corruption detected";
        public const string EXCEPTION_CACHE_FAILURE = "Distributed cache failure";
        
        // System Exceptions
        public const string EXCEPTION_DISK_FULL = "Storage disk space exhausted";
        public const string EXCEPTION_CPU_OVERLOAD = "CPU threshold exceeded";
        public const string EXCEPTION_NETWORK_LATENCY = "Network latency exceeded tolerance";
        
        // Security Exceptions
        public const string EXCEPTION_INTRUSION_DETECTED = "Security intrusion detected";
        public const string EXCEPTION_MALWARE_FOUND = "Malicious software detected";
        public const string EXCEPTION_DDOS_ATTACK = "DDoS attack mitigation triggered";
    }
}