import React from "react";
import logo from "./logo.svg";
import "./styles/App.css";
import { Drill } from "./types/drill";
import DrillPreviewCard from "./components/DrillPreviewCard";

function App() {
  const sampleDrill = {
    id: "3qhe897e",
    name: "co-op rally",
    description: `
      keep the rally going with the intended techniques used during a normal match. 
      Ideally the first touch would be a bump, 
      second would be a set and 
      third a soft attack or tip
      `,
    atleastMinutes: 5,
    recommendedMinutes: 10,
    skills: ["Passing", "Reception", "Setting", "Tipping", "Attacking"],
  };
  return (
    <main>
      <h1>Components of vbsessionplanner</h1>
      <section>
        <h2>&lt;Drill /&gt;</h2>
        <DrillPreviewCard drill={sampleDrill} />
      </section>
    </main>
  );
}

export default App;
