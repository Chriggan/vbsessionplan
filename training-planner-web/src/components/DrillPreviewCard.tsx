import React from "react";
import { Drill } from "../types/drill";
import {
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  CardMedia,
  Tooltip,
  Typography,
} from "@mui/material";

const DrillPreviewCard = ({ drill }: { drill: Drill }) => {
  console.log(drill);

  const formattedSkills = drill.skills.map((skill) => {
    return <h3 style={{ margin: ".5rem 0" }}>{skill}</h3>;
  });

  return (
    <Card sx={{ maxWidth: 345 }}>
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardMedia
          sx={{ height: 180 }}
          image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUy_7M3ou6-lWO8ti6tLWB8YZKjFiVTl5gauVIKWJAIg&s"
          title="green iguana"
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="div">
            {drill.name}
          </Typography>
          <Typography variant="body2" color="text.secondary">
            {drill.description}
          </Typography>
        </CardContent>
      </Box>
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardActions>
          <Button size="small">Share</Button>
          <Button size="small">Learn More</Button>
          <Tooltip
            title={formattedSkills}
            arrow
            enterDelay={500}
            leaveDelay={200}
          >
            <Button size="small">Skills</Button>
          </Tooltip>
        </CardActions>
      </Box>
    </Card>
  );
};

export default DrillPreviewCard;
