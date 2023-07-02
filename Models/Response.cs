namespace Detect_Toxic_Text.Models;
public record Response(float processing_time, float confidence_score, string result);
