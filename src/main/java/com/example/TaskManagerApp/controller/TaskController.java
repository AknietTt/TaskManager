package com.example.TaskManagerApp.controller;

import com.example.TaskManagerApp.entity.Task;
import com.example.TaskManagerApp.service.TaskService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@Controller
@RequestMapping("/main")
public class TaskController {
    @Autowired
    private TaskService taskService;
    @GetMapping()
    public String getAll(Model model){
        List<Task> tasks = taskService.getAll();
        model.addAttribute("taskList",tasks);
        model.addAttribute("taskSize",tasks.size());
        return "index";
    }
    @GetMapping("/delete/{id}")
    public String delete(@PathVariable int id){
        taskService.delete(id);
        return "redirect:/main";
    }
    @PostMapping("/add")
    public String addTask(@ModelAttribute Task task) {
        taskService.save(task);
        return "redirect:/main";
    }


}
