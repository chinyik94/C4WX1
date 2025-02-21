namespace C4WX1.API.Features.Chat.Constants
{
    public class ChatSqls
    {
        public const string ListLatest =
            """
            SELECT 
                d."ChatID",
                d."Comment",
                d."Attachment",
                d."Attachment_Physical",
                d."ParentID_FK",
                d."PatientID_FK",
                d."CreatedDate",
                d."CreatedBy_FK",
                d."IsDeleted",
                d."Family",
                u."UserId" AS "UserData_UserId",
                u."Firstname" AS "UserData_Firstname",
                u."Lastname" AS "UserData_Lastname",
                u."Photo" AS "UserData_Photo",
                p."PatientID" AS "PatientData_PatientID",
                p."Firstname" AS "PatientData_Firstname",
                p."Lastname" AS "PatientData_Lastname",
                p."Photo" AS "PatientData_Photo",
                e."ChatID" AS "CommentList_ChatID",
                e."Comment" AS "CommentList_Comment",
                e."Attachment" AS "CommentList_Attachment",
                e."Attachment_Physical" AS "CommentList_Attachment_Physical",
                e."ParentID_FK" AS "CommentList_ParentID_FK",
                e."PatientID_FK" AS "CommentList_PatientID_FK",
                e."CreatedDate" AS "CommentList_CreatedDate",
                e."CreatedBy_FK" AS "CommentList_CreatedBy_FK",
                eu."UserId" AS "CommentList_UserData_UserId",
                eu."Firstname" AS "CommentList_UserData_Firstname",
                eu."Lastname" AS "CommentList_UserData_Lastname",
                eu."Photo" AS "CommentList_UserData_Photo"
            FROM "Chat" d
            LEFT JOIN "Users" u ON d."CreatedBy_FK" = u."UserId"
            LEFT JOIN "Patient" p ON d."PatientID_FK" = p."PatientID"
            LEFT JOIN "Chat" e ON e."ParentID_FK" = d."ChatID" AND e."IsDeleted" = FALSE
            LEFT JOIN "Users" eu ON e."CreatedBy_FK" = eu."UserId"
            WHERE d."IsDeleted" = FALSE
              AND (d."PatientID_FK" = @patientId OR @patientId IS NULL)
              AND ("fn_CanAccessPatient"(@userId, d."PatientID_FK") = TRUE OR @userId IS NULL)
              AND d."ParentID_FK" IS NULL
              AND (d."Family" = @family OR @family IS NULL OR (@family = FALSE AND d."Family" IS NULL))
              AND d."ChatID" > @chatId
            ORDER BY d."CreatedDate" DESC
            LIMIT @count;
            """;
        public const string ListLatestChild =
            """
            SELECT 
                d."ChatID",
                d."Comment",
                d."Attachment",
                d."Attachment_Physical",
                d."ParentID_FK",
                d."PatientID_FK",
                d."CreatedDate",
                d."CreatedBy_FK",
                d."IsDeleted",
                u."UserId" AS "UserData_UserId",
                u."Firstname" AS "UserData_Firstname",
                u."Lastname" AS "UserData_Lastname",
                u."Photo" AS "UserData_Photo",
                p."PatientID" AS "PatientData_PatientID",
                p."Firstname" AS "PatientData_Firstname",
                p."Lastname" AS "PatientData_Lastname",
                p."Photo" AS "PatientData_Photo",
                e."ChatID" AS "CommentList_ChatID",
                e."Comment" AS "CommentList_Comment",
                e."Attachment" AS "CommentList_Attachment",
                e."Attachment_Physical" AS "CommentList_Attachment_Physical",
                e."ParentID_FK" AS "CommentList_ParentID_FK",
                e."PatientID_FK" AS "CommentList_PatientID_FK",
                e."CreatedDate" AS "CommentList_CreatedDate",
                e."CreatedBy_FK" AS "CommentList_CreatedBy_FK",
                eu."UserId" AS "CommentList_UserData_UserId",
                eu."Firstname" AS "CommentList_UserData_Firstname",
                eu."Lastname" AS "CommentList_UserData_Lastname",
                eu."Photo" AS "CommentList_UserData_Photo"
            FROM "Chat" d
            LEFT JOIN "Users" u ON d."CreatedBy_FK" = u."UserId"
            LEFT JOIN "Patient" p ON d."PatientID_FK" = p."PatientID"
            LEFT JOIN "Chat" e ON e."ParentID_FK" = d."ChatID" AND e."IsDeleted" = FALSE
            LEFT JOIN "Users" eu ON e."CreatedBy_FK" = eu."UserId"
            WHERE d."IsDeleted" = FALSE
              AND (@patientId IS NULL OR d."PatientID_FK" = @patientId)
              AND (@userId IS NULL OR "fn_CanAccessPatient"(@userId, d."PatientID_FK") = TRUE)
              AND d."ParentID_FK" IS NOT NULL
              AND (@parentIds IS NULL OR NOT d."ParentID_FK" = ANY(@parentIds))
              AND (@family IS NULL OR 
                   (@family = FALSE AND d."Family" IS NULL) OR 
                   d."Family" = @family)
              AND d."ChatID" > @chatId
            ORDER BY d."CreatedDate" DESC
            LIMIT @count;
            """;
        public const string ListPrevious =
            """
            SELECT 
                d."ChatID",
                d."Comment",
                d."Attachment",
                d."Attachment_Physical",
                d."ParentID_FK",
                d."PatientID_FK",
                d."CreatedDate",
                d."CreatedBy_FK",
                d."IsDeleted",
                d."Family",
                u."UserId" AS "UserData_UserId",
                u."Firstname" AS "UserData_Firstname",
                u."Lastname" AS "UserData_Lastname",
                u."Photo" AS "UserData_Photo",
                p."PatientID" AS "PatientData_PatientID",
                p."Firstname" AS "PatientData_Firstname",
                p."Lastname" AS "PatientData_Lastname",
                p."Photo" AS "PatientData_Photo",
                e."ChatID" AS "CommentList_ChatID",
                e."Comment" AS "CommentList_Comment",
                e."Attachment" AS "CommentList_Attachment",
                e."Attachment_Physical" AS "CommentList_Attachment_Physical",
                e."ParentID_FK" AS "CommentList_ParentID_FK",
                e."PatientID_FK" AS "CommentList_PatientID_FK",
                e."CreatedDate" AS "CommentList_CreatedDate",
                e."CreatedBy_FK" AS "CommentList_CreatedBy_FK",
                eu."UserId" AS "CommentList_UserData_UserId",
                eu."Firstname" AS "CommentList_UserData_Firstname",
                eu."Lastname" AS "CommentList_UserData_Lastname",
                eu."Photo" AS "CommentList_UserData_Photo"
            FROM "Chat" d
            LEFT JOIN "Users" u ON d."CreatedBy_FK" = u."UserId"
            LEFT JOIN "Patient" p ON d."PatientID_FK" = p."PatientID"
            LEFT JOIN "Chat" e ON e."ParentID_FK" = d."ChatID" AND e."IsDeleted" = FALSE
            LEFT JOIN "Users" eu ON e."CreatedBy_FK" = eu."UserId"
            WHERE d."IsDeleted" = FALSE
              AND (d."PatientID_FK" = @patientId OR @patientId IS NULL)
              AND ("fn_CanAccessPatient"(@userId, d."PatientID_FK") = TRUE OR @userId IS NULL)
              AND d."ParentID_FK" IS NULL
              AND (d."Family" = @family OR @family IS NULL OR (@family = FALSE AND d."Family" IS NULL))
              AND (@chatId IS NULL OR d."ChatID" < @chatId)
            ORDER BY d."CreatedDate" DESC
            LIMIT @count;
            """;
        public const string CanLoadMore = """
            SELECT 1
            FROM "Chat"
            WHERE "IsDeleted" = FALSE
                AND (@patientId IS NULL OR "PatientID_FK" = @patientId)
                AND (@userId IS NULL OR "fn_CanAccessPatient"(@userId, "PatientID_FK"))
                AND "ChatID" < @minChatId;
            """;
    }
}
