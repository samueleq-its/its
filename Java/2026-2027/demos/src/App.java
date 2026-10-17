import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class App {
    public static void main(String[] args) throws Exception {
        runTest();
    }

    public static void runTest() {
        HashMap<String, String> tests = new HashMap<>();

        tests.put("<em></em>", "true");
        tests.put("<em><p></p></em>", "true");
        tests.put("<em><p><div></div><em></em></p></em>", "true");
        tests.put("<em>", "em");
        tests.put("<em><p></em>", "/em");
        tests.put("<em><div></div><em></em></p></em>", "/p");
        tests.put("<em><p><div></div></em></p></em>", "false");

        String[] keys = tests.keySet().toArray(new String[0]);
        for (int i = 0; i < keys.length; i++) {
            String result = verifyHTML(keys[i]);
            System.out.println("result: " + result + ", exprected: " + tests.get(keys[i]));
        }

    }

    public static String verifyHTML(String html) {
        System.out.println("######################"); // DEBUG

        Pattern tagPattern = Pattern.compile("(</?[a-z]*>)");
        Matcher htmlMatcher = tagPattern.matcher(html);

        List<String> openTags = new ArrayList<>();
        String result = "true";
        boolean errorFound = false;

        while (htmlMatcher.find()) {
            String tag = htmlMatcher.group();
            System.out.print(tag); // DEBUG

            if (tagIsOpening(tag)) {
                System.out.print(" is opening"); // DEBUG

                openTags.add(tag);
            } else {
                System.out.print(" is closing"); // DEBUG

                if (openTags.isEmpty()) {
                    if (errorFound) {
                        return "false";
                    }
                    errorFound = true;
                    result = tag.replaceAll("[<,>]", "");
                }

                if (openCloseTagsMatch(openTags.getLast(), tag)) {
                    openTags.removeLast();
                } else {
                    if (errorFound) {
                        return "false";
                    } else {
                        errorFound = true;
                        result = tag.replaceAll("[<>]", "");
                    }
                }

            }
            System.out.println(); // DEBUG
        }

        if (openTags.size() > 1) {
            return "false";
        }
        if (openTags.size() == 1) {
            return openTags.getFirst().replaceAll("[<>]", "");
        }

        return result;
    }

    public static boolean tagIsOpening(String tag) {
        return tag.charAt(1) != '/';
    }

    public static boolean openCloseTagsMatch(String openingTag, String closingTag) {
        return openingTag.equals(closingTag.replace("/", ""));
    }
}
