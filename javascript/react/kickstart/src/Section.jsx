import { useContext } from "react";
import { TestContext } from "./testContext";

export default function Section({ children })
{
    const level = useContext(TestContext);
    return (
        <section className="section">
            <TestContext.Provider value={level + 1}>
                {children}
            </TestContext.Provider>
        </section>
    );
}